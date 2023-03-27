<template>
  <div class="container-fluid">
    <h3 class="my-2 border-bottom border-dark text-danger">Form a Cult</h3>
    <form class="row" @submit.prevent="createCult">
      <div class="mb-3">
        <label for="" class="form-label">Name</label>
        <input type="text" class="form-control" v-model="editable.name" name="name" id="" aria-describedby="helpId"
          placeholder="">
      </div>
      <div class="mb-3">
        <label for="" class="form-label">Description</label>
        <input type="text" class="form-control" v-model="editable.description" name="description" id=""
          aria-describedby="helpId" placeholder="">
      </div>
      <div class="mb-3">
        <label for="" class="form-label">Category</label>
        <input type="text" class="form-control" v-model="editable.category" name="category" id=""
          aria-describedby="helpId" placeholder="">
      </div>

      <button class="btn btn-success">Get Culting</button>
    </form>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createCult() {
        try {
          logger.log('creating cult', editable.value)
          await cultsService.createCult(editable.value)
        } catch (error) {
          logger.error(error)
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped></style>
