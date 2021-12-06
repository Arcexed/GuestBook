import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Notes from "@/components/Notes.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/notes",
        name: "Notes",
        component: Notes,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;