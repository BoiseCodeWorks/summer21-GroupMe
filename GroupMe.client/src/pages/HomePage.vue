<template>
  <div>
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-4 col-md-6" v-for="g in groups" :key="g.id">
          <GroupCard :group="g" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { groupsService } from '../services/GroupsService'

export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      groupsService.getGroups()
    })
    return reactive({
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      groups: computed(() => AppState.groups)
    })
  }
}
</script>

<style scoped lang="scss">

</style>
