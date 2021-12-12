import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/Home.vue";
import NotesPage from "@/views/NotesPage";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/notes",
        Name: "Notes",
        component: NotesPage
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;