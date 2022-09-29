<script setup lang="ts">
import { onMounted } from 'vue';
import { useMainStore } from '@/stores/main-store'
import Info from '@/components/layouts/Info.vue'

const mainStore = useMainStore()
mainStore.$patch({ selectedFilterTypeKey: 'weapon' })
onMounted(() => mainStore.loadSoldiers())
onMounted(() => mainStore.loadWeapons())

function getWeaponDetails(weapon: any) {
  let {
    range,
    length,
    mass,
  } = weapon

  let arr: { title: String, info: String }[] = [];
  arr.push({ title: "Range", info: `${range} m` });
  arr.push({ title: "Length", info: `${length} m` });
  arr.push({ title: "Mass", info: `${mass} Kg` });

  return arr;
}
</script>

<template>
  <h1 v-if="(mainStore.filteredWeapons as any[]).length === 0">
    {{ mainStore.isLoading ? 'Loading' : `No ${String($route.name)}` }}
  </h1>
  <div class="card shadow border-0 rounded-0 mb-3" v-for="weapon in (mainStore.filteredWeapons as any[])">
    <div class="card-body">
      <div class="d-flex flex-column flex-md-row">
        <div class="col">
          <div class="fw-bold sans tag bg-dark text-light rounded text-uppercase d-inline me-2">
            {{ weapon.weaponType.name }}
          </div>
          <div class="fw-bold sans tag bg-dark text-light rounded text-uppercase d-inline" v-if="weapon.isNuclear">
            <i class="bi bi-radioactive text-warning rounded"></i>
            nuclear
          </div>
          <h2 class="card-title w-max" style="margin-left: -2px;">
            {{ weapon.name }}
            <button type="button" @click="$router.push(`/weapons/edit/${weapon.id}`)"
              class="btn btn-sm btn-outline-army-500 me-1"><i class="bi bi-pencil"></i></button>
            <button type="button" @click="mainStore.deleteWeapon(weapon.id)"
              class="btn btn-sm btn-outline-danger mx-1"><i class="bi bi-trash3"></i></button>
          </h2>
          <p class="card-text text-army-500 pt-3 custom-class"> {{ weapon.description }}</p>
        </div>
        <Info :details="getWeaponDetails(weapon)" />
      </div>
    </div>
  </div>
</template>