<template>
  <div class="card m-4 shadow">
    <img :src="group.img" v-if="group.img" alt="" class="card-img-top">
    <div class="card-body">
      <h3>
        {{ group.name }}
      </h3>
      <p>{{ group.description }}</p>
      <div>
        <router-link :to="{name: 'Group', params: {id: group.id}}">
          group details
        </router-link>
      </div>
    </div>
    <div class="card-footer text-right">
      <b>{{ group.creator.name }}</b>
      <img :src="group.creator.picture" alt="group creator image" class="rounded-circle elevation-1 mx-2" height="40">
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'

export default {
  props: {
    group: { type: Object, required: true }
  },
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style>

</style>
