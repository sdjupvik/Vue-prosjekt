<script setup lang="ts">
import { useMainStore } from '@/stores/main-store'
var mainStore = useMainStore()
</script>

<template>
  <h1 class="container-fluid pt-3 fw-bolder text-army-300 text-uppercase">{{ $route.name }}</h1>
  <div class="container-fluid border-0 border-army-200 py-1 d-flex justify-content-between">
    <div class="btn-group d-none d-md-block shadow" role="group" aria-label="filters">
      <template v-for="(filter, i) in mainStore.selectedFilterType.data">
        <input type="radio" class="btn-check" :id="`check-filter-${filter.id}`" autocomplete="offaa" name="filter"
          v-model="mainStore.selectedFilterType.selectedFilter" :value="filter">
        <label class="btn btn-outline-army-500" :for="`check-filter-${filter.id}`">{{
            filter.name
        }}</label>
      </template>
    </div>
    <div class="dropdown d-block d-md-none">
      <button class="btn btn-outline-army-500 dropdown-toggle" type="button" id="filters-dropdown-trigger"
        data-bs-toggle="dropdown">
        {{ mainStore.selectedFilterType.selectedFilter.name }}
      </button>
      <ul class="dropdown-menu">
        <li>
          <a class="dropdown-item" href="#" @click.prevent="mainStore.selectedFilterType.selectedFilter = filter"
            v-for="(filter, i) in mainStore.selectedFilterType.data">
            {{ filter.name }}
          </a>
        </li>
      </ul>
    </div>
    <RouterLink :to="`${$route.fullPath}/add`" class="btn btn-army-500"><i class="bi bi-plus-lg"></i> Add
      {{ $route.name }}</RouterLink>
  </div>
  <div class="container-fluid py-5">
    <slot></slot>
  </div>
</template>

<style lang="scss">
</style>