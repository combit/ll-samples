import { NavLink, Outlet } from "react-router-dom";
import "./App.css";

/**
 * Application shell: header, navigation and the routed page.
 */
export default function App() {
  return (
    <div className="app">
      <header className="app-header">
        <div className="app-logo">
          <svg width="28" height="28" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
            <path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" />
            <polyline points="14 2 14 8 20 8" />
            <line x1="16" y1="13" x2="8" y2="13" />
            <line x1="16" y1="17" x2="8" y2="17" />
            <polyline points="10 9 9 9 8 9" />
          </svg>
          <span>List &amp; Label Web Reporting</span>
        </div>
        <nav className="app-nav">
          <NavLink to="/designer" className={({ isActive }) => `tab-button ${isActive ? "active" : ""}`}>
            Designer
          </NavLink>
          <NavLink to="/viewer" className={({ isActive }) => `tab-button ${isActive ? "active" : ""}`}>
            Viewer
          </NavLink>
        </nav>
      </header>
      <main className="app-content">
        <Outlet />
      </main>
    </div>
  );
}
