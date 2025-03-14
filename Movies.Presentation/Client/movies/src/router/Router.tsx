import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import MovieForm from "../components/movies/MovieForm";

export const routes: RouteObject[] =
    [
        {
            path: '/',
            element: <App />,
            children: [
                { path: 'createMovie', element: <MovieForm key='create' /> },
                { path: 'editMovie/:id', element: <MovieForm key='edit' /> },
                { path: '*', element: <MovieForm/> }
            ]
        }
    ]

export const router = createBrowserRouter(routes)