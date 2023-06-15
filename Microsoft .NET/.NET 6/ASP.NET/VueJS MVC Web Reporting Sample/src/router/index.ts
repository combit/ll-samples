import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import WebReportDesignerView from '../views/WebReportDesignerView.vue'
import WebReportViewerView from '../views/WebReportViewerView.vue'

const routes: Array<RouteRecordRaw> = [
    {
    path: '/',
    name: 'home',
    component: HomeView
    },
    {
        path: '/WebReportDesigner',
        name: 'webReportDesigner',
        component: WebReportDesignerView
    },
    {
        path: '/WebReportViewer',
        name: 'webReportViewer',
        component: WebReportViewerView
    },
    {
        path: '/:pathMatch(.*)*',
        name: 'home',
        component: HomeView
    }
]



const router = createRouter({
  history: createWebHistory(),
    routes,
})

export default router
