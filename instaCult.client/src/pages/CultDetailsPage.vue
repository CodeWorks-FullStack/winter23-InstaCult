<template>
  <div class="container-fluid">
    <section v-if="cult" class="row text-light">

      <div class="col-6">
        <img class="img-fluid" :src="cult.leader.picture" alt="">
        <h2>{{ cult.leader.name }}</h2>
      </div>
      <div class="col-6">
        <h2>{{ cult.name }}</h2>
        <h3>{{ cult.category }}</h3>
        <p>{{ cult.description }}</p>
      </div>
    </section>

  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, onUnmounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { useRoute } from 'vue-router';
export default {
  setup() {
    const route = useRoute()
    onMounted(() => {
      getCultById()
    })
    async function getCultById() {
      try {
        await cultsService.getCultById(route.params.cultId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    return {
      cult: computed(() => AppState.activeCult)
    }
  }
};
</script>


<style lang="scss" scoped></style>
