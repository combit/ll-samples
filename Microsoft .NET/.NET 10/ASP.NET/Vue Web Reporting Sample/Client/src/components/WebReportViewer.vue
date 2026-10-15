<script setup lang="ts">
import { useExternalScript } from "../composables/useExternalScript";
import { useSampleDefaults } from "../composables/useSampleDefaults";
import { config } from "../config";

const { state } = useExternalScript(config.wrvScriptUrl);
const { defaults } = useSampleDefaults();
</script>

<template>
  <div class="component-wrapper">
    <!-- D:   Das Element darf erst erscheinen, wenn die Vorgaben geladen sind - defaultProject
             wird nur beim Erzeugen des Elements ausgewertet.
         US: The element must not appear before the defaults are loaded - defaultProject is only
             evaluated when the element is created. -->
    <div v-if="state === 'loading' || !defaults" class="loading-container">
      <div class="spinner"></div>
      <p>Loading Web Report Viewer...</p>
    </div>
    <div v-else-if="state === 'error'" class="error-container">
      <p>
        Failed to load Web Report Viewer script.<br />
        Please ensure the backend is running at
        <code>{{ config.backendBaseUrl }}</code
        >.
      </p>
    </div>
    <div v-else class="viewer-container">
      <ll-webreportviewer
        :backendurl="config.wrvBackendUrl"
        :defaultProject="defaults.viewerProject || undefined"
        style="width: 100%; height: 100%"
      ></ll-webreportviewer>
    </div>
  </div>
</template>

<style scoped>
.component-wrapper {
  width: 100%;
  height: 100%;
}
.viewer-container {
  width: 100%;
  height: 100%;
}
</style>
