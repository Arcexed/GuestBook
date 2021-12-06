<template>
  <nav-menu></nav-menu>
  <router-view />
</template>

<script>
    import NavMenu from './components/NavMenu.vue'

export default {
  name: 'App',
  components: {
      NavMenu
  }
}
</script>

<style>
*{
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}
li{
  list-style:none;
}
a{
  text-decoration: none;
  color: inherit;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.container{
  width: 1200px;
  margin: 0 auto
}

</style>
