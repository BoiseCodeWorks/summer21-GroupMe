<template>
  <div class="d-flex align-items-center mb-3">
    <img :src="profile.picture" alt="group creator image" class="rounded-circle elevation-1 mx-2" height="60">
    <div class="d-flex flex-column ml-3">
      <b>{{ profile.name }}</b>
      <small class="text-uppercase">{{ member.role }}</small>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
export default {
  props: {
    member: { type: Object, required: true }
  },
  setup(props) {
    return {
      profile: computed(() => props.member.profile)
    }
  }
}
</script>

<style>

</style>
