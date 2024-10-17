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
				
                {/* US: Comment this line in if you have set the example in file "DefaultSettings.cs" to English.*/}
				{state === "ready" && <ll-webreportdesigner backendurl="https://localhost:7146/LLWebReportDesigner" defaultProject="42B325E5-A894-4BDE-9D0A-5098B46A5085" showTutorial />}
				
                {/* D: Kommentieren Sie diese Zeile ein, wenn Sie das Beispiel in Datei "DefaultSettings.cs" auf Deutsch gestellt haben.*/}
                {/* state === "ready" && <ll-webreportdesigner backendurl="https://localhost:7146/LLWebReportDesigner" defaultProject="305D94C6-E5DC-4BE1-BC43-12CBC532EEE6" showTutorial /> */}
            </div>
        </div>
    );
}
