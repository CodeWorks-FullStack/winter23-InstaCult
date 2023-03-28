import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";


class CultsService {

  async getCults() {
    const res = await api.get('api/cults')
    logger.log('[Got Cults]', res.data)
    AppState.cults = res.data
  }

  async createCult(cultData) {
    const res = await api.post('api/cults', cultData)
    logger.log('[Created Cult]', res.data)
    AppState.cults.push(res.data)
  }

  /**
   *
   * @param {number} id
   * gets a cult by its numerical sequential primary key value.
   * saves requested data to Appstate.activeCult
   */
  async getCultById(id) {
    AppState.activeCult = null
    const url = ['api', 'cults', `${id}`] // this is goofy nonsense, just having fun
    const res = await api.get(url.join('/'))
    logger.log('[GET ONE CULT]', res.data)
    AppState.activeCult = res.data
  }

  async getCultMembers(id) {
    const res = await api.get(`api/cults/${id}/cultmembers`)
    logger.log('[GET CULT MEMBERS]', res.data)
    AppState.cultMembers = res.data
  }

}

export const cultsService = new CultsService();
