<script setup lang="ts">
import { RouterView } from 'vue-router'
import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'

</script>

<template>
  <Header />
  <component :is="$route.meta.layout">
    <RouterView />
  </component>
  <Footer />
</template>

<style lang="sass">
  @import '@/scss/bootstrap.index.scss'
  @import '../node_modules/bootstrap-icons/font/bootstrap-icons.css'
  @import url('https://fonts.googleapis.com/css2?family=Arvo:ital,wght@0,400;0,700;1,400;1,700&display=swap') 
  @import url('https://fonts.googleapis.com/css2?family=Arvo:ital,wght@0,400;0,700;1,400;1,700&family=Encode+Sans+Semi+Expanded:wght@600&display=swap')
  @import '@/scss/index'
</style>
