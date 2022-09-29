<script setup lang="ts">
import { onMounted } from 'vue';
import { useMainStore } from '@/stores/main-store'
import { formatDate } from '@/service/utilities'
import Info from '@/components/layouts/Info.vue'

const mainStore = useMainStore()
mainStore.$patch({ selectedFilterTypeKey: 'soldier' })
onMounted(() => mainStore.loadSoldiers())

function getSoldierDetails(soldier: any) {
  let {
    recruitedOn,
    dateOfBirth,
    height,
    weight,
    chestWidth
  } = soldier

  let arr: { title: String, info: String }[] = [];
  arr.push({ title: "Recruited", info: formatDate(recruitedOn) });
  arr.push({ title: "Born On", info: formatDate(dateOfBirth) });
  arr.push({ title: "Height", info: `${height} cm` })
  arr.push({ title: "Weight", info: `${weight} Kg` })
  arr.push({ title: "Chest width", info: `${chestWidth} cm` })

  return arr;
}
</script>

<template>
  <h1 v-if="(mainStore.filteredSoldiers as any[]).length === 0">No {{ $route.name }}</h1>
  <div class="card shadow border-0 rounded-0 mb-3" v-for="soldier in (mainStore.filteredSoldiers as any[])">
    <div class="card-body">
      <div class="d-flex flex-column flex-md-row">
        <div class="col">
          <div class="fw-bold sans tag bg-dark text-light rounded text-uppercase d-inline">
            {{ soldier.soldierRank.name }}
          </div>
          <div class="fw-bold sans tag bg-danger text-light rounded text-uppercase d-inline ms-1"
            v-if="soldier.isSpecialForces">
            special forces
          </div>
          <h2 class="card-title w-max" style="margin-left: -2px;">
            {{ soldier.firstName }} {{ soldier.lastName }}
            <button type="button" @click="$router.push(`/soldiers/edit/${soldier.id}`)"
              class="btn btn-sm btn-outline-army-500 me-1"><i class="bi bi-pencil"></i></button>
            <button type="button" @click="mainStore.deleteSoldier(soldier.id)"
              class="btn btn-sm btn-outline-danger mx-1"><i class="bi bi-trash3"></i></button>
          </h2>
          <p class="card-text text-army-500 pt-3 custom-class"> {{ soldier.address }}</p>
          <div>
            <h6 class="card-title ps-0 w-max fs-5 mb-0"> Expertise </h6>
            <span class="card-text text-army-500 fw-lighter me-3" v-for="expertise in soldier.soldierExpertises">
              {{ expertise.name }}
            </span>
          </div>
        </div>
        <Info :details="getSoldierDetails(soldier)" />
      </div>

    </div>
  </div>
</template>