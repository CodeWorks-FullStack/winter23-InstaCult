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
    <section v-if="account.id">
      <button v-if="!inCult" @click="joinCult" class="btn btn-danger w-100"><i class="mdi mdi-account"></i><i
          class="mdi mdi-plus"></i>Join now!</button>
    </section>
    <section class="d-flex flex-wrap">
      <CultMemberCard v-for="cm in cultMembers" :cultMember="cm" />
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
import { cultMembersService } from '../services/CultMembersService.js'
export default {
  setup() {
    const route = useRoute()
    onMounted(() => {
      getCultById()
      getCultMembers()
    })
    async function getCultById() {
      try {
        await cultsService.getCultById(route.params.cultId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    async function getCultMembers() {
      try {
        await cultsService.getCultMembers(route.params.cultId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    async function joinCult() {
      try {
        await cultMembersService.joinCult(route.params.cultId)
      } catch (error) {
        logger.error(error)
        Pop.error(error)
      }
    }
    return {
      account: computed(() => AppState.account),
      cult: computed(() => AppState.activeCult),
      cultMembers: computed(() => AppState.cultMembers),
      inCult: computed(() => AppState.cultMembers.find(cm => cm.id == AppState.account.id)),
      joinCult
    }
  }
};
</script>


<style lang="scss" scoped></style>
