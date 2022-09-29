<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useMainStore } from '@/stores/main-store'
import { apiPost } from '@/service'
import router from '@/router'

const mainStore = useMainStore()
onMounted(() => mainStore.loadSoldierExpertise())

let newSoldier = ref({
  firstName: '',
  lastName: '',
  address: '',
  expertises: [],
  isSpecialForce: false,
  rank: 0,
  height: 0,
  weight: 0,
  chestWidth: 0,
  dateOfBirth: new Date()
})

async function saveSoldier() {
  await apiPost('soldier', newSoldier.value)
  router.push('/soldiers')
}
</script>

<template>
  <form class="text-army-500 custom-class" @submit.prevent="saveSoldier">
    <div class="d-block d-md-flex justify-content-md-between">
      <div class="form-group">
        <label for="rank">Rank</label>
        <select class="form-select" id="rank" v-model="newSoldier.rank">
          <option v-for="rank in mainStore.filters.find(x => x.type === 'soldier')?.data.filter(x => x.id)"
            :value="rank.id">
            {{ rank.name }}
          </option>
        </select>
      </div>

      <div class="form-group">
        <label for="firstname">First name</label>
        <input class="form-control" id="firstname" v-model="newSoldier.firstName" />
      </div>
      <div class="form-group">
        <label for="name">Last name</label>
        <input class="form-control" id="name" v-model="newSoldier.lastName" />
      </div>
    </div>

    <div class="form-group mt-3">
      <label for="address">Address</label>
      <textarea class="form-control" id="address" rows="3" v-model="newSoldier.address"></textarea>
    </div>


    <div class="form-group mt-3">
      <div class="form-check">
        <input class="form-check-input" type="checkbox" id="special" v-model="newSoldier.isSpecialForce">
        <label class="form-check-label" for="special">
          Is special force commando
        </label>
      </div>
    </div>

    <div class="d-block d-md-flex justify-content-md-between mt-3">
      <div class="form-group mt-3">
        <label>Select expertise</label>
        <div class="form-check" v-for="expertise in (mainStore.soldierExpertises as any[])">
          <input class="form-check-input" type="checkbox" :value="expertise.id" :id="`expertise-${expertise.id}`"
            v-model="newSoldier.expertises">
          <label class="form-check-label" :for="`expertise-${expertise.id}`">
            {{ expertise.name }}
          </label>
        </div>
      </div>
      <div class="form-group mt-3">
        <label for="height">Height (cm)</label>
        <input class="form-control form-control-sm" id="height" v-model="newSoldier.height" type="number" />
        <label for="weight">Weight (Kg)</label>
        <input class="form-control form-control-sm" id="weight" v-model="newSoldier.weight" type="number" />
        <label for="chest">Chest width (cm)</label>
        <input class="form-control form-control-sm" id="chest" v-model="newSoldier.chestWidth" type="number" />
        <label for="dateofbirth">Date of birth</label>
        <input class="form-control form-control-sm" id="dateofbirth" v-model="newSoldier.dateOfBirth" type="date" />
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
</style>