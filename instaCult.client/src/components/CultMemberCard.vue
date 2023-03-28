<template>
  <div class="component">
    <div class="card">
      <img :src="cultMember.picture" alt="">
      <h5 class="clip-text">{{ cultMember.name }}</h5>
      <button @click="leaveCult" v-if="cultMember.id == account.id" title="go ON GIT. AKA leave cult"><i
          class="mdi mdi-door-open"></i><i class="mdi mdi-arrow-right"></i></button>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { cultMembersService } from '../services/CultMembersService.js';
export default {
  props: { cultMember: { type: Object, required: true } },
  setup(props) {
    return {
      account: computed(() => AppState.account),
      async leaveCult() {
        try {
          let cultMemberId = props.cultMember.cultMemberId
          await cultMembersService.leaveCult(cultMemberId)
        } catch (error) {
          logger.error(error)
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.component {
  width: 17%;
  padding: 1em;
}
</style>
