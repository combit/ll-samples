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
                                                                                                                    {/*US: You can define the ClientData String and pass it to provideListLabelContext here*/}
                                                                                                                    {/*D:  Definition eines ClientData strings welcher an provideListLabelContext weitergegeben wird*/}
                {state === "ready" && <ll-webreportdesigner backendurl="https://localhost:7146/LLWebReportDesigner" showTutorial clientData="{'testdata':'Im a test object'}" />}
				
            </div>
        </div>
    );
}
