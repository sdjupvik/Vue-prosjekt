<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useMainStore } from '@/stores/main-store'
import { apiPost } from '@/service'
import router from '@/router'

const mainStore = useMainStore()
onMounted(() => mainStore.loadSoldiers())

let newMission = ref({
  name: '', description: '', soldiers: []
})

async function saveMission() {
  await apiPost('mission', newMission.value)
  router.push('/missions')
}
</script>

<template>
  <form class="text-army-500 custom-class" @submit.prevent="saveMission">
    <div class="form-group">
      <label for="name">Mission name</label>
      <input class="form-control" id="name" v-model="newMission.name" />
    </div>
    <div class="form-group mt-3">
      <label for="description">Description</label>
      <textarea class="form-control" id="description" rows="3" v-model="newMission.description"></textarea>
    </div>
    <div class="form-group mt-3">
      <label for="soldiers">Select soldiers</label>
      <div class="form-check" v-for="soldier in (mainStore.soldiers as any[])">
        <input class="form-check-input" type="checkbox" :value="soldier.id" :id="`soldier-${soldier.id}`"
          v-model="newMission.soldiers">
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
      <span class="ms-2">Save</span>
    </button>
  </form>
</template>

<style scoped lang="scss">
.smaller {
  font-size: smaller;
}
</style>