<template>
  <div id="app">
    <Header />
    <Menu />
    <Content />
  </div>
</template>

<script>
import Header from './components/layout/TheHeader.vue'
import Menu from './components/layout/TheMenu.vue'
import Content from './components/layout/TheContent.vue'
import { CommonFn } from "./js/mixins.js";

export default {
  mixins: [CommonFn],
  name: 'App',
  components: {
    Header,
    Menu,
    Content
  }
}
</script>


<style>
  @import './css/main.css';
</style>
