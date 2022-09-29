<script setup lang="ts">
import { useMainStore } from '@/stores/main-store'
import { onMounted } from 'vue'
import Info from '@/components/layouts/Info.vue'

const mainStore = useMainStore()
mainStore.$patch({ selectedFilterTypeKey: 'mission' })

onMounted(() => mainStore.loadMissions())

function formatDate(dateString: string | null): string {
  return dateString ? Intl.DateTimeFormat('nb').format(new Date(dateString)) : ''
}

function getMissionDetails(mission: any) {
  let {
    planningStartedOn,
    missionCompletedOn,
    casualityCount,
    lossOfLifeCount,
    equipmentRepairCost,
    missionStatusId
  } = mission

  let arr: { title: String, info: String }[] = [];
  arr.push({ title: "Planning", info: formatDate(planningStartedOn) });

  if (missionStatusId === 3 || missionStatusId === 4) {
    arr.push({ title: "Completed", info: formatDate(missionCompletedOn) });
  }

  if (missionStatusId === 2 || missionStatusId === 3 || missionStatusId === 4) {
    arr.push({ title: "Casualities", info: casualityCount })
    arr.push({ title: "Loss of life", info: lossOfLifeCount })
    arr.push({ title: "Equipment damage", info: `Kr ${equipmentRepairCost}` })
  }

  return arr;
}
</script>

<template>
  <h1 v-if="(mainStore.filteredMissions as any[]).length === 0">
    {{ mainStore.isLoading ? 'Loading' : `No ${String($route.name)}` }}
  </h1>
  <div class="card shadow border-0 rounded-0 mb-3" v-for="mission in (mainStore.filteredMissions as any[])">
    <div class="card-body">
      <div class="d-flex flex-column flex-md-row">
        <div class="col">
          <div class="fw-bold sans tag bg-dark text-light rounded text-uppercase" style="">
            {{ mission.missionStatus.name }}
          </div>
          <h2 class="card-title w-max" style="margin-left: -2px;">
            {{ mission.name }}
            <button type="button" @click="$router.push(`/missions/edit/${mission.id}`)"
              class="btn btn-sm btn-outline-army-500 me-1"><i class="bi bi-pencil"></i></button>
            <button type="button" @click="mainStore.deleteMission(mission.id)"
              class="btn btn-sm btn-outline-danger mx-1"><i class="bi bi-trash3"></i></button>
          </h2>
          <h6 class="card-title ps-0 w-max" hidden> Commanded by
            <span class="card-text text-army-500 fw-bolder">Major Tom Cruise</span>
          </h6>
          <p class="card-text text-army-500 pt-3 custom-class"> {{ mission.description }}</p>
          <div>
            <h6 class="card-title ps-0 w-max fs-5 mb-0"> Soldiers </h6>
            <span class="card-text text-army-500 fw-lighter me-3" v-for="soldier in mission.soldiers">
              {{ soldier.firstName }} {{ soldier.lastName }}
            </span>
          </div>
        </div>
        <Info :details="getMissionDetails(mission)" />
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>