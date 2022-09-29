<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useMainStore } from '@/stores/main-store'
import { apiPost } from '@/service'
import router from '@/router'

const mainStore = useMainStore()

let newWeapon = ref({
  name: '',
  description: '',
  isNuclear: false,
  range: 0,
  length: 0,
  mass: 0,
  type: 0
})

async function saveWeapon() {
  await apiPost('weapon', newWeapon.value)
  router.push('/weapons')
}
</script>

<template>
  <form class="text-army-500 custom-class" @submit.prevent="saveWeapon">
    <div class="d-block d-md-flex justify-content-md-between">
      <div class="form-group">
        <label for="firstname">Name</label>
        <input class="form-control" id="firstname" v-model="newWeapon.name" />
      </div>

      <div class="form-group">
        <label for="rank">Weapon type</label>
        <select class="form-select" v-model="newWeapon.type">
          <option v-for="type in mainStore.filters.find(x => x.type === 'weapon')?.data.filter(x => x.id)"
            :value="type.id">
            {{ type.name }}
          </option>
        </select>
      </div>
    </div>

    <div class="form-group mt-3">
      <label for="address">Description</label>
      <textarea class="form-control" id="address" rows="3" v-model="newWeapon.description"></textarea>
    </div>

    <div class="d-block d-md-flex justify-content-md-between mt-3">

      <div class="form-group">
        <div class="form-check">
          <input class="form-check-input" type="checkbox" id="special" v-model="newWeapon.isNuclear">
          <label class="form-check-labe" for="special">
            this is a nuclear weapon <i class="bi bi-radioactive bg-army-200 p-1 rounded"></i>
          </label>
        </div>
      </div>
    </div>

    <div class="d-block d-md-flex justify-content-md-between my-3">
      <div class="form-group">
        <label for="mass">Mass (in Kg)</label>
        <input type="number" class="form-control" id="mass" v-model="newWeapon.mass" min="1" />
      </div>
      <div class="form-group">
        <label for="length">Length (in mm)</label>
        <input type="number" class="form-control" id="length" v-model="newWeapon.length" min="1" />
      </div>
      <div class="form-group">
        <label for="range">Range (in m)</label>
        <input type="number" class="form-control" id="range" v-model="newWeapon.range" min="1" />
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