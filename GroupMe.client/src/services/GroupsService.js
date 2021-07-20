import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { api } from './AxiosService'

class GroupsService {
  async getGroups() {
    const res = await api.get('api/groups')
    AppState.groups = res.data
  }

  async getGroupById(id) {
    AppState.group = {}
    const res = await api.get(`api/groups/${id}`)
    AppState.group = res.data
  }

  async getGroupMembers(groupId) {
    AppState.members = []
    const res = await api.get(`api/groups/${groupId}/members`)
    AppState.members = res.data
  }

  async leaveGroup(g) {
    await api.delete(`api/groupmembers/${g.id}`)
    Pop.toast(`Left group ${g.name}`)
    // router.push({ name: 'Group', params: { id: g.id } })
  }

  async createGroup(group) {
    const res = await api.post('api/groups', group)
    Pop.toast(`Created group ${group.name}`)
    AppState.groups.push(res.data)
  }

  async updateGroup(g) {
    await api.put(`api/groups/${g.id}`, g)
    Pop.toast(`Updated group ${g.name}`)
  }

  async deleteGroup(g) {
    await api.delete(`api/groups/${g.id}`)
    Pop.toast(`Deleted group ${g.name}`)
  }

  async joinGroup(g) {
    await api.post('api/groupmembers', {
      groupId: g.id
    })
    Pop.toast(`Joined group ${g.name}`)
  }
}

export const groupsService = new GroupsService()
