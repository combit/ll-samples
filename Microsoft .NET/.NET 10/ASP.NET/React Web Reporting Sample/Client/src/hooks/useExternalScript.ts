import { useEffect, useState } from "react";

type ScriptState = "loading" | "ready" | "error";

/**
 * Hook to dynamically load an external script.
 * Ensures the script is loaded only once even in React 19 StrictMode.
 */
export function useExternalScript(url: string): ScriptState {
  const [state, setState] = useState<ScriptState>(() => {
    // Check if script is already in the document
    const existing = document.querySelector(`script[src="${url}"]`);
    if (existing) {
      return existing.getAttribute("data-loaded") === "true"
        ? "ready"
        : "loading";
    }
    return "loading";
  });

  useEffect(() => {
    // Check if script already exists (prevents duplicate in StrictMode)
    let script = document.querySelector(
      `script[src="${url}"]`
    ) as HTMLScriptElement | null;

    if (script) {
      if (script.getAttribute("data-loaded") === "true") {
        setState("ready");
        return;
      }
      // Script exists but still loading – attach listeners
      const onLoad = () => setState("ready");
      const onError = () => setState("error");
      script.addEventListener("load", onLoad);
      script.addEventListener("error", onError);
      return () => {
        script?.removeEventListener("load", onLoad);
        script?.removeEventListener("error", onError);
      };
    }

    // Create and append the script
    script = document.createElement("script");
    script.src = url;
    script.async = true;

    script.addEventListener("load", () => {
      script!.setAttribute("data-loaded", "true");
      setState("ready");
    });

    script.addEventListener("error", () => {
      setState("error");
    });

    document.head.appendChild(script);

    // Cleanup: do NOT remove the script on unmount to avoid reloading
    // in StrictMode's double-mount cycle. The script is idempotent.
  }, [url]);

  return state;
}
