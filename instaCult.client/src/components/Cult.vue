<template>
  <div class="row" @click="clicked">
    <div class="col-12 p-0 bg-dark border rounded elevation-2">
      <img :src="cult.leader.picture" alt="">
      <div class="p-2">
        <router-link :to="{
          name: 'CultDetails', params: { cultId: cult.id }
        }">
          <h3 class="text-center text-primary">{{ cult.name }}</h3>
        </router-link>
        <p>{{ cult.description }}</p>
      </div>
    </div>
  </div>
</template>


<script setup>
import { onMounted } from 'vue';
import { logger } from '../utils/Logger.js';

const props = defineProps({ cult: { type: Object, required: true }, })

onMounted(() => {
  logger.log('mounted', props.cult.name)
})

function clicked() {
  logger.log('clicked', props.cult.name)
}
</script>


<style lang="scss" scoped>
img {
  height: 15vh;
  width: 100%;
  object-fit: cover;
}
</style>
