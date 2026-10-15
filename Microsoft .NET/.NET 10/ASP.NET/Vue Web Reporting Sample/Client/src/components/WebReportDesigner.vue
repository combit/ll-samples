<script setup lang="ts">
import { useExternalScript } from "../composables/useExternalScript";
import { useSampleDefaults } from "../composables/useSampleDefaults";
import { config } from "../config";

const { state } = useExternalScript(config.wrdScriptUrl);
const { defaults } = useSampleDefaults();
</script>

<template>
  <div class="component-wrapper">
    <!-- D:   Das Element darf erst erscheinen, wenn die Vorgaben geladen sind - defaultProject
             wird nur beim Erzeugen des Elements ausgewertet. Beim ersten Start ist der Wert
             leer, dann zeigt der Designer seine eigene Auswahlseite.
         US: The element must not appear before the defaults are loaded - defaultProject is only
             evaluated when the element is created. On first start the value is empty, so the
             designer shows its own selection page. -->
    <div v-if="state === 'loading' || !defaults" class="loading-container">
      <div class="spinner"></div>
      <p>Loading Web Report Designer...</p>
    </div>
    <div v-else-if="state === 'error'" class="error-container">
      <p>
        Failed to load Web Report Designer script.<br />
        Please ensure the backend is running at
        <code>{{ config.backendBaseUrl }}</code
        >.
      </p>
    </div>
    <div v-else class="designer-container">
      <ll-webreportdesigner
        :backendUrl="config.wrdBackendUrl"
        :defaultProject="defaults.startupProject || undefined"
        :showTutorial="config.showTutorial"
        style="width: 100%; height: 100%"
      ></ll-webreportdesigner>
    </div>
  </div>
</template>

<style scoped>
.component-wrapper {
  width: 100%;
  height: 100%;
}
.designer-container {
  width: 100%;
  height: 100%;
}
</style>
