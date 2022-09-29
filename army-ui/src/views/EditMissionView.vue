<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useMainStore } from '@/stores/main-store'
import { apiGet, apiPut } from '@/service'
import router from '@/router'

const mainStore = useMainStore()
mainStore.loadSoldiers()

let missionId = Number(router.currentRoute.value.params['id'])

let mission = ref({
  name: '', description: '', soldiers: [], status: 0, damage: 0
})

let filters = (mainStore.filters.find(x => x.type === 'mission')?.data)?.filter(x => x.id)

onMounted(async () => {
  let _mission = await apiGet(`mission/${missionId}`)
  mission.value.name = _mission.name
  mission.value.status = _mission.missionStatusId
  mission.value.damage = _mission.equipmentRepairCost
  mission.value.soldiers = _mission.soldiers.map((x: any) => x.id)
  mission.value.description = _mission.description
})

async function updateMission() {
  await apiPut(`mission/${missionId}`, mission.value)
  router.push('/missions')
}
</script>

<template>
  <form class="text-army-500 custom-class" @submit.prevent="updateMission">
    <div class="form-group">
      <label for="name">Mission name</label>
      <input class="form-control" id="name" v-model="mission.name" />
    </div>
    <div class="form-group mt-3">
      <label for="description">Description</label>
      <textarea class="form-control" id="description" rows="3" v-model="mission.description"></textarea>
    </div>
    <div class="form-group mt-3">
      <label for="soldiers" class="d-block">Mission status</label>
      <div class="form-check form-check-inline" v-for="status in filters">
        <input class="form-check-input" type="radio" name="status" :value="status.id" :id="`status-${status.id}`"
          v-model="mission.status">
        <label class="form-check-label" :for="`status-${status.id}`">
          <span class="fw-bolder smaller">{{ status.name }}</span>
        </label>
      </div>
    </div>
    <div class="form-group mt-3">
      <label for="damage">Equipment damage</label>
      <input type="number" class="form-control" id="damage" v-model="mission.damage">
    </div>
    <div class="form-group mt-3">
      <label for="soldiers">Select soldiers</label>
      <div class="form-check" v-for="soldier in (mainStore.soldiers as any[])">
        <input class="form-check-input" type="checkbox" :value="soldier.id" :id="`soldier-${soldier.id}`"
          v-model="mission.soldiers">
        <label class="form-check-label" :for="`soldier-${soldier.id}`">
          <span class="fw-bolder smaller">{{ soldier.soldierRank.name }}</span>
          {{ soldier.firstName }} {{ soldier.lastName }}
        </label>
      </div>
    </div>
    <button class="btn btn-sm me-3 mt-3 mb-5 sans" type="reset">
      <i class="bi bi-x-square-fill"></i> Clear
    </button>
    <button class="btn btn-sm btn-army-500 mt-3 mb-5 me-1">
      <i class="bi bi-save"></i>
      <span class="ms-2">Update</span>
    </button>
  </form>
</template>

<style scoped lang="scss">
.smaller {
  font-size: smaller;
}
</style>