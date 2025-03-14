import { Outlet, useLocation } from 'react-router-dom';
import './App.css'
import MovieTable from "./components/movies/MovieTable.tsx";
import { Container } from 'semantic-ui-react';
import React from "react";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
    const location = useLocation();

    return (
        <>
            <ToastContainer />
            {location.pathname === '/' ? <MovieTable /> : (
                <Container className="container-style">
                    <Outlet />
                </Container>
            )}
        </>
    )
}

export default App