import { useState, useEffect } from "react";
import { MovieDto } from "../../models/movieDto.ts";
import apiConnector from "../../api/apiConnector.ts";
import { Button, Container, Modal } from "semantic-ui-react";
import MovieTableItem from "./MovieTableItem.tsx";
import MovieForm from "./MovieForm.tsx";

export default function MovieTable() {
    const [movies, setMovies] = useState<MovieDto[]>([]);
    const [open, setOpen] = useState(false);
    const [selectedMovie, setSelectedMovie] = useState<MovieDto | null>(null);

    useEffect(() => {
        fetchMovies();
    }, []);

    async function fetchMovies() {
        const fetchedMovies = await apiConnector.getMovies();
        setMovies(fetchedMovies);
    }

    function handleEdit(movie: MovieDto) {
        setSelectedMovie(movie);
        setOpen(true);
    }

    function handleAdd() {
        setSelectedMovie(null);
        setOpen(true);
    }

    async function handleClose() {
        await fetchMovies(); // Reload movies when modal closes
        setOpen(false);
    }

    return (
        <>
          <div className='main ui container'>
            <Container className="container-style">
                <h2 className='ui dividing header'>
                    Movies
                </h2>
                <table className="ui inverted table">
                    <thead style={{ textAlign: 'center' }}>
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>CreateDate</th>
                            <th>Category</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {movies.length !== 0 &&
                            movies.map((movie, index) => (
                                <MovieTableItem key={index} movie={movie} onEdit={handleEdit} onDelete={handleClose} />
                            ))
                        }
                    </tbody>
                </table>
                <Button floated="right" type="button" content="Add Movie" positive onClick={handleAdd}></Button>
            </Container>


            {/* Modal for Add/Edit Movie */}
            <Modal open={open} onClose={handleClose} size="small">
                <Modal.Header>{selectedMovie ? "Edit Movie" : "Add Movie"}</Modal.Header>
                <Modal.Content>
                    <MovieForm movieData={selectedMovie} onClose={handleClose} />
                </Modal.Content>
                </Modal>
            </div>
        </>
    );
}
