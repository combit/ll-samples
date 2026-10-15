import { useLayoutEffect, useRef } from "react";
import { useExternalScript } from "../hooks/useExternalScript";
import { useSampleDefaults } from "../hooks/useSampleDefaults";
import { config } from "../config";

type LlWebReportViewerElement = HTMLElement & {
    backendUrl?: string;
    backendurl?: string;
    defaultProject?: string;
};

/**
 * WebReportViewer component.
 * Loads the WRV script and renders the ll-webreportviewer custom element.
 *
 * The WebComponent itself is rendered by React.
 * Configuration is assigned through DOM properties via ref.
 */
export function WebReportViewer() {
    const state = useExternalScript(config.wrvScriptUrl);
    const defaults = useSampleDefaults();
    const viewerRef = useRef<LlWebReportViewerElement | null>(null);

    useLayoutEffect(() => {
        const viewer = viewerRef.current;

        if (state !== "ready" || !viewer || !defaults) {
            return;
        }

        viewer.backendUrl = config.wrvBackendUrl;

        if (defaults.viewerProject) {
            viewer.defaultProject = defaults.viewerProject;
        }
    }, [state, defaults]);

    // The element must not render before the defaults are known - defaultProject is only
    // evaluated when the element mounts.
    if (state === "loading" || !defaults) {
        return (
            <div className="loading-container">
                <div className="spinner" />
                <p>Loading Web Report Viewer...</p>
            </div>
        );
    }

    if (state === "error") {
        return (
            <div className="error-container">
                <p>
                    Failed to load Web Report Viewer script.
                    <br />
                    Please ensure the backend is running at{" "}
                    <code>{config.backendBaseUrl}</code>.
                </p>
            </div>
        );
    }

    return (
        <ll-webreportviewer
            ref={viewerRef}
            style={{ width: "100%", height: "100%" }}
        />
    );
}
