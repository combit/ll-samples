import { useEffect, useState } from "react";

export const useExternalScript = (url) => {
    let [state, setState] = useState(url ? "loading" : "idle");

    useEffect(() => {
        if (!url) {
            setState("idle");
            return;
        }
        let scriptTag = document.querySelector(`script[src="${url}"]`);

        const handleScript = (e) => {
            setState(e.type === "load" ? "ready" : "error");
        };

        if (!scriptTag) {
            scriptTag = document.createElement("script");
            scriptTag.type = "application/javascript";
            scriptTag.src = url;
            scriptTag.async = true;
            document.body.appendChild(scriptTag);
            scriptTag.addEventListener("load", handleScript);
            scriptTag.addEventListener("error", handleScript);
        }

        scriptTag.addEventListener("load", handleScript);
        scriptTag.addEventListener("error", handleScript);

        return () => {
            scriptTag.removeEventListener("load", handleScript);
            scriptTag.removeEventListener("error", handleScript);
        };
    }, [url]);

    return state;
};