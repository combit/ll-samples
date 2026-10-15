<script setup lang="ts">
/**
 * Application shell: header, navigation and the routed page.
 */
</script>

<template>
  <div class="app">
    <header class="app-header">
      <div class="app-logo">
        <svg
          width="28"
          height="28"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="2"
        >
          <path
            d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"
          />
          <polyline points="14 2 14 8 20 8" />
          <line x1="16" y1="13" x2="8" y2="13" />
          <line x1="16" y1="17" x2="8" y2="17" />
          <polyline points="10 9 9 9 8 9" />
        </svg>
        <span>List &amp; Label Web Reporting</span>
      </div>
      <nav class="app-nav">
        <router-link to="/designer" class="tab-button" active-class="active"
          >Designer</router-link
        >
        <router-link to="/viewer" class="tab-button" active-class="active"
          >Viewer</router-link
        >
      </nav>
    </header>
    <main class="app-content">
      <router-view />
    </main>
  </div>
</template>
