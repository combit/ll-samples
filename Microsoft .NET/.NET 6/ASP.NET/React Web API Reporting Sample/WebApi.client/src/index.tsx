import React from 'react';
import {createRoot} from 'react-dom/client';
import './index.css';
import App from './App';
import {createBrowserRouter, RouterProvider } from 'react-router-dom';
import { WebReportDesigner } from './WebReportDesigner';
import { WebReportViewer } from './WebReportViewer';


const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
    },
    {
        path: "WebReportDesigner",
        element: <WebReportDesigner />,
    },
    {
        path: "WebReportViewer",
        element: <WebReportViewer />,
    }
])

createRoot(document.getElementById('root') as Element).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
)



