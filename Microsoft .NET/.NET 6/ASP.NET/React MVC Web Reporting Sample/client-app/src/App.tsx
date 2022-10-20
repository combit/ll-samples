import './App.css';

function App() {
    const openInNewTab = (link: string | undefined) => {
        window.open(link, "_blank")
    }


  return (
      <div className="App">
          <div>
              <h1 className="Headline">React Web Reporting Sample</h1>
                <p>
                  DE: In diesem Beispiel wird die Einbindung des WebReportDesigners und des WebReportViewers mit einem ASP.NET Core Backend und einem React Frontend gezeigt.
                </p>
                <p>
                  EN: This example shows the integration of the WebReportDesigner and the WebReportViewer with an ASP.NET Core backend and a React frontend.
              </p>
              <form className="Form">
                  <button onClick={() => openInNewTab("/WebReportDesigner")} className="button" name="Design">
                      Design
                  </button>
                  <button onClick={() => openInNewTab("/WebReportViewer")} className="button" name="Preview">
                      Preview
                  </button>
              </form>
          </div>
      </div>
  );
}

export default App;