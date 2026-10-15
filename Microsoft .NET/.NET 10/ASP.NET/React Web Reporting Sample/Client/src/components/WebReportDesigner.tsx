import { useLayoutEffect, useRef } from "react";
import { useExternalScript } from "../hooks/useExternalScript";
import { useSampleDefaults } from "../hooks/useSampleDefaults";
import { config } from "../config";

type LlWebReportDesignerElement = HTMLElement & {
    backendUrl?: string;
    defaultProject?: string;
    showTutorial?: boolean;
};

/**
 * WebReportDesigner component.
 * Loads the WRD script and renders the ll-webreportdesigner custom element.
 *
 * Configuration is assigned through DOM properties via ref.
 */
export function WebReportDesigner() {
    const state = useExternalScript(config.wrdScriptUrl);
    const defaults = useSampleDefaults();
    const designerRef = useRef<LlWebReportDesignerElement | null>(null);

    useLayoutEffect(() => {
        const designer = designerRef.current;

        if (state !== "ready" || !designer || !defaults) {
            return;
        }

        designer.backendUrl = config.wrdBackendUrl;

        // Empty on first start - the designer then shows its own selection page.
        // See DefaultSettings.StartupProject.
        if (defaults.startupProject) {
            designer.defaultProject = defaults.startupProject;
        }

        designer.showTutorial = config.showTutorial;
    }, [state, defaults]);

    // The element must not render before the defaults are known - defaultProject is only
    // evaluated when the element mounts.
    if (state === "loading" || !defaults) {
        return (
            <div className="loading-container">
                <div className="spinner" />
                <p>Loading Web Report Designer...</p>
            </div>
        );
    }

    if (state === "error") {
        return (
            <div className="error-container">
                <p>
                    Failed to load Web Report Designer script.
                    <br />
                    Please ensure the backend is running at{" "}
                    <code>{config.backendBaseUrl}</code>.
                </p>
            </div>
        );
    }

    return <ll-webreportdesigner id="webReportDesigner" ref={designerRef} />;
}
