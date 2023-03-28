import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CultMembersService {
  async joinCult(cultId) {
    const res = await api.post('api/cultmembers', { cultId })
    logger.log('[CONGRATULATIONS YOU JOINED A CULT]', res.data)
    // NOTE {...object} creates a copy of the object, which we add an additional property to, so we can fake the new cultMember in the cultMembers array
    let fakedCultMember = { ...AppState.account, cultMemberId: res.data.id }
    AppState.cultMembers.push(fakedCultMember)
  }

  async leaveCult(cultMemberId) {
    const res = await api.delete(`api/cultmembers/${cultMemberId}`)
    logger.log('[Left the cult]', res.data)
    AppState.cultMembers = AppState.cultMembers.filter(cm => cm.cultMemberId != cultMemberId)
  }
}

export const cultMembersService = new CultMembersService()
