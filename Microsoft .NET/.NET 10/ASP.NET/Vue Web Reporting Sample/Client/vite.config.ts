import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

export default defineConfig({
  plugins: [
    vue({
      template: {
        compilerOptions: {
          // Treat List & Label custom elements as native
          isCustomElement: (tag) => tag.startsWith("ll-"),
        },
      },
    }),
  ],
  server: {
    port: 3100,
    proxy: {
      "/api": {
        target: "https://localhost:7148",
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
