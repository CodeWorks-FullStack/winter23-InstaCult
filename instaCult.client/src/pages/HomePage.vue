<template>
  <div class="container-fluid">
    <section class="row text-light ">
      <div v-for="c in cults" class="col-6 col-md-3 ">
        <div class="p-2">
          <Cult :cult="c" />
        </div>
      </div>
    </section>
    <!-- Modal trigger button -->
    <button v-if="account.id" type="button" class="btn btn-info btn-lg rounded-pill" data-bs-toggle="modal"
      data-bs-target="#create-cult" title="create cult">
      <i class="mdi mdi-plus"></i><i class="mdi mdi-candle"></i>
    </button>

    <Modal id="create-cult">
      <CultForm />
    </Modal>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';

export default {
  setup() {
    onMounted(() => {
      getCults()
    })
    async function getCults() {
      try {
        await cultsService.getCults()
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    return {
      cults: computed(() => AppState.cults),
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
