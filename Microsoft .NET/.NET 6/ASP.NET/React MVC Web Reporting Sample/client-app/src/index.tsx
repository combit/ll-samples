import React from 'react';
import {createRoot} from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
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

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
