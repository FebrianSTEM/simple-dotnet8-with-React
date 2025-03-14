import axios, { AxiosResponse } from "axios";
import { GetMovieResponse } from "../models/getMoviesResponse";
import { MovieDto } from "../models/movieDTO";
import { GetMovieByIdResponse } from "../models/getMovieByIdResponse.ts";

const apiConnector = {

    getMovieById: async (id: number): Promise<MovieDto | undefined> => {
        try {
            const response: AxiosResponse<GetMovieByIdResponse> = await axios.get(`/api/movies/${id}`);
            const movie = response.data.movieDto;

            return movie;
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    },

    getMovies: async (): Promise<MovieDto[]> => {
        try {
            const response: AxiosResponse<GetMovieResponse> = await axios.get(`/api/movies`);
            const movies = response.data.moviesDtos.map(movie => ({
                ...movie,
                createDate: movie.createdDate?.slice(0, 10) ?? ""
            }));

            return movies;

        }
        catch (error)
        {
            console.log('errror fetching movies:', error);
            throw error;
        }
    },

    createMovie: async (movie: MovieDto): Promise<void> => {
        try {
            await axios.post<number>(`/api/movies`, movie);
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    },

    editMovie: async (movie: MovieDto): Promise<void> => {
        try {
            await axios.put<number>(`/api/movies/${movie.id}`, movie);
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    },

    deleteMovie: async (id: number): Promise<void> => {
        try {
            await axios.delete<number>(`/api/movies/${id}`);
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    }
}

export default apiConnector;