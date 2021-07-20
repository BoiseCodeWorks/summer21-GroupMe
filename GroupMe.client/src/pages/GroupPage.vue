<template>
  <div>
    <GroupCard :group="group" />
    <div class="card m-3 p-5">
      <h5 class="text-uppercase">
        Members
      </h5>
      <div v-for="m in members" :key="m.id">
        <Member :member="m" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { groupsService } from '../services/GroupsService'
import { AppState } from '../AppState'
export default {
  setup() {
    const route = useRoute()
    watchEffect(() => {
      const id = route.params.id
      if (!id) { return }
      groupsService.getGroupById(id)
      groupsService.getGroupMembers(id)
    })

    return {
      group: computed(() => AppState.group),
      members: computed(() => AppState.members)
    }
  }
}
</script>

<style>

</style>
