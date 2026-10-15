import { ref, onMounted } from "vue";

type ScriptState = "loading" | "ready" | "error";

/**
 * Composable to dynamically load an external script.
 * Ensures the script is loaded only once across all component instances.
 */
export function useExternalScript(url: string) {
  const state = ref<ScriptState>("loading");

  onMounted(() => {
    // Check if script already exists
    let script = document.querySelector(
      `script[src="${url}"]`
    ) as HTMLScriptElement | null;

    if (script) {
      if (script.getAttribute("data-loaded") === "true") {
        state.value = "ready";
        return;
      }
      // Script exists but still loading – attach listeners
      const onLoad = () => {
        state.value = "ready";
      };
      const onError = () => {
        state.value = "error";
      };
      script.addEventListener("load", onLoad);
      script.addEventListener("error", onError);
      return;
    }

    // Create and append the script
    script = document.createElement("script");
    script.src = url;
    script.async = true;

    script.addEventListener("load", () => {
      script!.setAttribute("data-loaded", "true");
      state.value = "ready";
    });

    script.addEventListener("error", () => {
      state.value = "error";
    });

    document.head.appendChild(script);
  });

  return { state };
}
