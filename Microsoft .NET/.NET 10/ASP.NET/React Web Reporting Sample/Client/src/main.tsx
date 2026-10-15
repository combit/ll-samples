import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, Navigate, RouterProvider } from "react-router-dom";
import App from "./App";
import { Wrd } from "./pages/Wrd";
import { Wrv } from "./pages/Wrv";
import { WebReportDesigner } from "./components/WebReportDesigner";
import { WebReportViewer } from "./components/WebReportViewer";
import "./App.css";

/*
 * D:   Zwei Ebenen: /designer und /viewer sind die Seiten mit Kopfzeile und Navigation, die der
 *      Benutzer sieht. Sie binden /wrd-frontend bzw. /wrv-frontend als iFrame ein - dort liegen
 *      die eigentlichen List & Label-Webkomponenten. Warum, steht in pages/Wrd.tsx.
 *
 *      Die *-frontend-Routen haengen bewusst nicht unter <App />, damit im iFrame keine zweite
 *      Kopfzeile erscheint.
 * US:  Two levels: /designer and /viewer are the pages with header and navigation that the user
 *      sees. They embed /wrd-frontend and /wrv-frontend respectively as an iFrame - that is where
 *      the actual List & Label web components live. The reason is documented in pages/Wrd.tsx.
 *
 *      The *-frontend routes deliberately do not sit under <App />, so that no second header
 *      appears inside the iFrame.
 */
const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { index: true, element: <Navigate to="/designer" replace /> },
      { path: "designer", element: <Wrd /> },
      { path: "viewer", element: <Wrv /> }
    ]
  },
  { path: "wrd-frontend", element: <WebReportDesigner /> },
  { path: "wrv-frontend", element: <WebReportViewer /> }
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
);
