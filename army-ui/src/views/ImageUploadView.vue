<script setup lang="ts">
import { getProfilePicturePath, uploadImage } from '@/service';
import { useMainStore } from '@/stores/main-store';
import { onMounted, ref } from 'vue';

let mainStore = useMainStore();

onMounted(async () => mainStore.loadProfilePicture())

async function save(e: Event) {
    let form = (e.target as HTMLFormElement)
    let body = new FormData(form)
    await uploadImage(body)
    mainStore.loadProfilePicture()
}

</script>

<template>
    <h3>Profile Picture</h3>
    <form @submit.prevent="save">
        <div class="profile-img">
            <label for="file" class="form-label">Select image</label>
            <input class="form-control" type="file" name="file" id="file" />
        </div>
        <button class="btn btn-sm btn-army-500 my-2">
            <i class="bi bi-save"></i>
            <span class="ms-2">Update</span>
        </button>
    </form>
    <div class="profile-picture-container">
        <img class="img-fluid rounded img-thumbnail" :src="mainStore.profilePictureUrl" alt="" />
    </div>

</template>

<style>
.profile-picture-container {
    width: 400px;
}
</style>