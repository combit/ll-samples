import { createApp } from "vue";
import { createRouter, createWebHistory } from "vue-router";
import App from "./App.vue";
import AppLayout from "./layouts/AppLayout.vue";
import Wrd from "./pages/Wrd.vue";
import Wrv from "./pages/Wrv.vue";
import WebReportDesigner from "./components/WebReportDesigner.vue";
import WebReportViewer from "./components/WebReportViewer.vue";

/*
 * D:   Zwei Ebenen: /designer und /viewer sind die Seiten mit Kopfzeile und Navigation, die der
 *      Benutzer sieht. Sie binden /wrd-frontend bzw. /wrv-frontend als iFrame ein - dort liegen
 *      die eigentlichen List & Label-Webkomponenten. Warum, steht in pages/Wrd.vue.
 *
 *      Die *-frontend-Routen haengen bewusst nicht unter AppLayout, damit im iFrame keine zweite
 *      Kopfzeile erscheint.
 * US:  Two levels: /designer and /viewer are the pages with header and navigation that the user
 *      sees. They embed /wrd-frontend and /wrv-frontend respectively as an iFrame - that is where
 *      the actual List & Label web components live. The reason is documented in pages/Wrd.vue.
 *
 *      The *-frontend routes deliberately do not sit under AppLayout, so that no second header
 *      appears inside the iFrame.
 */
const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      component: AppLayout,
      children: [
        { path: "", redirect: "/designer" },
        { path: "designer", component: Wrd },
        { path: "viewer", component: Wrv },
      ],
    },
    { path: "/wrd-frontend", component: WebReportDesigner },
    { path: "/wrv-frontend", component: WebReportViewer },
  ],
});

const app = createApp(App);
app.use(router);
app.mount("#app");
