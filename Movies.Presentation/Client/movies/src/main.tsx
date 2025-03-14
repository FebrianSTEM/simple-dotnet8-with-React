import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import 'semantic-ui-css/semantic.min.css';
import './App.css'
import { RouterProvider } from 'react-router-dom';
import { router } from './router/Router.tsx';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
        <RouterProvider router={router}></RouterProvider>
  </StrictMode>,
)