import { createApp } from "vue";
import { createPinia } from "pinia";

import App from "./App.vue";
import router from "./router";
import "bootstrap";

import MainLayout from "@/components/layouts/MainLayout.vue";
import FormLayout from "@/components/layouts/FormLayout.vue";

const app = createApp(App);

app.component("MainLayout", MainLayout);
app.component("FormLayout", FormLayout);

app.use(createPinia());
app.use(router);

app.mount("#app");
