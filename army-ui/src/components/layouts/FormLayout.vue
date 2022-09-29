<script setup lang="ts">

</script>

<template>

  <h1 class="container-fluid pt-3 fw-bolder text-army-300 text-uppercase">{{ $route.name }}</h1>

  <div class="container-fluid py-2">
    <slot></slot>
  </div>

</template>
