import React from 'react';
import { useExternalScript } from './hooks/useExternalScript';

export const WebReportViewer = () => {
    const state = useExternalScript("https://localhost:7260/WebReportViewer.js");

    return (
        <div>
            <div>
                <title>WebReportViewer</title>
            </div>
            <div>
                {state === "loading" && <p>Loading...</p>}
				
				{/* US: Comment this line in if you have set the example in file "DefaultSettings.cs" to English.*/}
				{state === "ready" && <ll-webreportviewer backendurl="https://localhost:7260/LLWebReportViewer" defaultProject="42B325E5-A894-4BDE-9D0A-5098B46A5085" />}
				
                {/* D: Kommentieren Sie diese Zeile ein, wenn Sie das Beispiel in Datei "DefaultSettings.cs" auf Deutsch gestellt haben.*/}
                {/* {state === "ready" && <ll-webreportviewer backendurl="https://localhost:7260/LLWebReportViewer" defaultProject="305D94C6-E5DC-4BE1-BC43-12CBC532EEE6" />}*/}
			</div>
        </div>
    );
}
