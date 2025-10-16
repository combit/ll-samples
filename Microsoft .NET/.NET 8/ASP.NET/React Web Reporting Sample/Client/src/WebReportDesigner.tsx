import { useExternalScript } from './hooks/useExternalScript';

export const WebReportDesigner = () => {
    const state = useExternalScript("https://localhost:7146/WebReportDesigner.js");

    return (
        <div>
            <div>
                <title>WebReportDesigner</title>
            </div>
            <div>
                {state === "loading" && <p>Loading...</p>}
                                
                {state === "ready" && <ll-webreportdesigner backendurl="https://localhost:7146/LLWebReportDesigner" showTutorial />}
				
            </div>
        </div>
    );
}
