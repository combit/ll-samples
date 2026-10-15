<template>
  <router-view />
</template>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

html,
body,
#app {
  height: 100%;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, sans-serif;
  background: #f5f7fa;
  color: #1a1a2e;
}

.app {
  display: flex;
  flex-direction: column;
  height: 100%;
  overflow: hidden;
}

.app-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 24px;
  height: 56px;
  background: #ffffff;
  border-bottom: 1px solid #e2e8f0;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.05);
  flex-shrink: 0;
}

.app-logo {
  display: flex;
  align-items: center;
  gap: 10px;
  font-weight: 600;
  font-size: 16px;
  color: #2563eb;
}

.app-nav {
  display: flex;
  gap: 4px;
}

.tab-button {
  padding: 8px 20px;
  border: none;
  background: transparent;
  border-radius: 6px;
  font-size: 14px;
  font-weight: 500;
  color: #64748b;
  cursor: pointer;
  transition: all 0.15s ease;
  text-decoration: none;
}

.tab-button:hover {
  background: #f1f5f9;
  color: #334155;
}

.tab-button.active {
  background: #2563eb;
  color: #ffffff;
}

.app-content {
  flex: 1;
  min-height: 0;
  position: relative;
  height: auto;
  overflow: hidden;
}

ll-webreportdesigner,
ll-webreportviewer {
  display: block;
  width: 100%;
  height: 100%;
  overflow: hidden;
}

.loading-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100%;
  gap: 16px;
  color: #64748b;
}

.spinner {
  width: 40px;
  height: 40px;
  border: 3px solid #e2e8f0;
  border-top-color: #2563eb;
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}

.error-container {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  padding: 32px;
}

.error-container p {
  background: #fef2f2;
  border: 1px solid #fecaca;
  border-radius: 8px;
  padding: 24px;
  color: #991b1b;
  max-width: 480px;
  text-align: center;
  line-height: 1.6;
}

.error-container code {
  background: #fee2e2;
  padding: 2px 6px;
  border-radius: 4px;
  font-size: 13px;
}

/* D:   Der iFrame, der Designer bzw. Viewer traegt - siehe pages/Wrd.vue.
   US:  The iFrame carrying the designer or viewer - see pages/Wrd.vue. */
.component-frame {
  display: block;
  width: 100%;
  height: 100%;
  border: 0;
}
</style>
