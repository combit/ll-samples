/**
 * Central configuration for the Vue Web Reporting sample.
 * Adjust these values to match your backend deployment.
 */
export const config = {
  /** Base URL of the ASP.NET Core backend (no trailing slash) */
  backendBaseUrl: "https://localhost:7148",

  /** Backend endpoint path for the WebReportDesigner controller */
  wrdEndpoint: "/LLWebReportDesigner",

  /** Backend endpoint path for the WebReportViewer controller */
  wrvEndpoint: "/LLWebReportViewer",

  /** Script URL for the WebReportDesigner web component */
  get wrdScriptUrl(): string {
    return `${this.backendBaseUrl}/WebReportDesigner.js`;
  },

  /** Script URL for the WebReportViewer web component */
  get wrvScriptUrl(): string {
    return `${this.backendBaseUrl}/WebReportViewer.js`;
  },

  /** Full backend URL for the WebReportDesigner */
  get wrdBackendUrl(): string {
    return `${this.backendBaseUrl}${this.wrdEndpoint}`;
  },

  /** Full backend URL for the WebReportViewer */
  get wrvBackendUrl(): string {
    return `${this.backendBaseUrl}${this.wrvEndpoint}`;
  },

  /**
   * Default project repository ID to open.
   * TODO: Replace with actual repository ID from your backend.
   */
  defaultProject: "",

  /** Whether to show the WRD tutorial on first launch */
  showTutorial: true,

  /** API endpoint to fetch default settings from the backend */
  get defaultsApiUrl(): string {
    return `${this.backendBaseUrl}/api/sample/defaults`;
  },
};
