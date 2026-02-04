<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>
import RevenueView from './views/View.vue';

export default {
  name: 'App',
  components: {
    RevenueView
  }
};
</script>

<style scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #1640cb;
  margin-top: 0;
}
header {
  background-color: #f06e0b;
  padding: 20px;
  color: white;
}
main {
  padding: 20px;
}
</style>
