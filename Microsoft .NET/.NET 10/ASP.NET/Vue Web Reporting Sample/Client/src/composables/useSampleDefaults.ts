import { ref, type Ref } from "vue";
import { config } from "../config";

export type SampleDefaults = {
    /** Report the designer starts with - empty on first start, then the last opened one. */
    startupProject?: string;
    /** Report the viewer shows - the designer's selection, otherwise the default report. */
    viewerProject?: string;
    defaultSelectedReport?: string;
    dataMember?: string;
    language?: string;
    unit?: string;
};

/**
 * Reads the defaults from the backend (see SampleController / DefaultSettings).
 * The repository IDs are resolved server-side, so no GUID is hardcoded in the client
 * and the correct report is found in both languages.
 *
 * Stays null while loading - callers must not render the web component before the value
 * is known, because defaultProject is only evaluated when the element mounts.
 */
export function useSampleDefaults(): { defaults: Ref<SampleDefaults | null> } {
    const defaults = ref<SampleDefaults | null>(null);

    (async () => {
        try {
            const response = await fetch(config.defaultsApiUrl);
            defaults.value = (await response.json()) as SampleDefaults;
        } catch {
            defaults.value = {};
        }
    })();

    return { defaults };
}
