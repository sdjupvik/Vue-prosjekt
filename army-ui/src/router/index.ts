import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      alias: '/index.html',
      redirect: "/missions",
    },
    {
      path: "/missions",
      name: "missions",
      component: () => import("../views/MissionView.vue"),
      meta: { layout: "MainLayout" },
    },
    {
      path: "/missions/add",
      name: "add mission",
      component: () => import("../views/AddMissionView.vue"),
      meta: { layout: "FormLayout" },
    },
    {
      path: "/missions/edit/:id",
      name: "edit mission",
      component: () => import("../views/EditMissionView.vue"),
      meta: { layout: "FormLayout" },
    },
    {
      path: "/soldiers",
      name: "soldiers",
      meta: { layout: "MainLayout" },
      component: () => import("../views/SoldierView.vue"),
    },
    {
      path: "/soldiers/add",
      name: "add soldier",
      component: () => import("../views/AddSoldierView.vue"),
      meta: { layout: "FormLayout" },
    },
    {
      path: "/soldiers/edit/:id",
      name: "edit soldier",
      component: () => import("../views/EditSoldierView.vue"),
      meta: { layout: "FormLayout" },
    },
    {
      path: "/weapons",
      name: "weapons",
      meta: { layout: "MainLayout" },
      component: () => import("../views/WeaponView.vue"),
    },
    {
      path: "/weapons/add",
      name: "add weapon",
      component: () => import("../views/AddWeaponView.vue"),
      meta: { layout: "FormLayout" },
    },
    {
      path: "/weapons/edit/:id",
      name: "edit weapon",
      component: () => import("../views/EditWeaponView.vue"),
      meta: { layout: "FormLayout" },
    },
    {
      path: "/settings",
      name: "settings",
      component: () => import("../views/ImageUploadView.vue"),
      meta: { layout: "FormLayout" },
    },
  ],
});

export default router;
