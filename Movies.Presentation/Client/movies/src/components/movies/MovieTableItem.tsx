import { Button } from "semantic-ui-react";
import { MovieDto } from "../../models/movieDto.ts";
import apiConnector from "../../api/apiConnector.ts";
import { toast } from "react-toastify";

interface Props {
    movie: MovieDto;
    onEdit: (movie: MovieDto) => void;
    onDelete: () => void;
}

export default function MovieTableItem({ movie, onEdit, onDelete }: Props) {
    return (
        <tr className="center aligned">
            <td data-label="Id">{movie.id}</td>
            <td data-label="Title">{movie.title}</td>
            <td data-label="Description">{movie.description}</td>
            <td data-label="CreateDate">{movie.createdDate?.slice(0,10)}</td>
            <td data-label="Category">{movie.category}</td>
            <td data-label="Action">
                <Button color="yellow" type="button" onClick={() => onEdit(movie)}>
                    Edit
                </Button>
                <Button type="button" negative onClick={async () => {
                    try {
                        await apiConnector.deleteMovie(movie.id!);
                        toast.success('Deleted successfully!');
                        onDelete(); // Trigger refresh after successful delete
                    } catch (error) {
                        toast.error('Failed to delete movie');
                    }
                }}>
                    Delete
                </Button>
            </td>
        </tr>
    );
}