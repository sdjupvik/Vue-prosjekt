<script setup lang="ts">
defineProps(['details'])
</script>

<template>
    <div class="p-2 pt-4 col col-md-4">
        <ul class="m-0 p-0 d-flex row gap-3">
            <li class="col p-0 mb-3" v-for="detail in details">
                <div class="sans w-100 min"> {{ detail.title }} </div>
                <div class="fw-bolder text-army-500"> {{ detail.info }}</div>
            </li>
        </ul>
    </div>
</template>