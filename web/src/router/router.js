import { createRouter, createWebHistory } from 'vue-router';
import View from '../views/View.vue';
import AddItem from '../views/AddItem.vue';

const routes = [
  
  {
    path: '/add',
    name: 'AddItem',
    component: AddItem
  },
  {
    path: '/',
    name: 'View',
    component: View
  }
];

const router = createRouter({
  history: createWebHistory(import.meta.env.VITE_BASE_URL),
  routes
});

export default router;
