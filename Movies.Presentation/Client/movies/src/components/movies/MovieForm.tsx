import { useState, useEffect, ChangeEvent } from "react";
import { Button, Form } from "semantic-ui-react";
import { MovieDto } from "../../models/movieDTO";
import apiConnector from "../../api/apiConnector.ts";
import { toast } from "react-toastify";

interface Props {
    movieData?: MovieDto; // Movie data passed from parent component (optional for Add)
    onClose: () => void; // Function to close modal
}

export default function MovieForm({ movieData, onClose }: Props) {
    const [movie, setMovie] = useState<MovieDto>({
        id: undefined,
        title: "",
        description: "",
        createdDate: undefined,
        category: ""
    });

    // Load movie data if editing
    useEffect(() => {
        if (movieData) {
            setMovie(movieData);
        }
    }, [movieData]);

    function handleSubmit(e: React.FormEvent) {
        e.preventDefault();

        if (!movie.id) {
            apiConnector.createMovie(movie).then(() => {
                toast.success('Movie added successfully!')
                onClose();
            }).catch(() => {
                toast.error("Failed to add movie. Please try again.");
            });
        } else {
            apiConnector.editMovie(movie).then(() => {
                toast.success('Movie edited successfuly!')
                onClose();
            }).catch(() => {
                toast.error("Failed to edit movie. Please try again.");
            });
        }
    }

    function handleInputChange(e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = e.target;
        setMovie({ ...movie, [name]: value });
    }

    return (
        <div className="ui inverted clearing segment">
            <Form className="ui inverted form" onSubmit={handleSubmit} autoComplete="off">
                <div className="field">
                    <label>Title</label>
                    <input placeholder="Title" name="title" value={movie.title} onChange={handleInputChange} />
                </div>
                <div className="field">
                    <label>Description</label>
                    <textarea placeholder="Description" name="description" value={movie.description} onChange={handleInputChange} />
                </div>
                <div className="field">
                    <label>Category</label>
                    <input placeholder="Category" name="category" value={movie.category} onChange={handleInputChange} />
                </div>
                <div></div>
                <Button floated="right" positive type="submit" content="Submit" />
                <Button floated="right" type="button" content="Cancel" onClick={onClose} />
            </Form>
        </div>
    );
}