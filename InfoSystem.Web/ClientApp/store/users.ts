import axios from 'axios'
import { User } from '../models/user'
import * as api from './api/api'

import { VuexModule, Module, MutationAction, Action } from 'vuex-module-decorators'

@Module({
  name: 'users',
  stateFactory: true,
  namespaced: true
})
export default class UsersModule extends VuexModule {
  token: string = ''
  login: string = ''

  get Login() {
    return this.login
  }

  @MutationAction
  async authenticate(user: User) {
    let response = await axios({ method: 'get', url: `/api/User/LogIn?login=${user.login}&password=${user.password}` })
    window.localStorage['token'] = response.data.token
    window.localStorage['login'] = response.data.login
    api.setJWT(response.data.token)
    return {
      token: response.data.token,
      login: response.data.login
    }
  }
  @MutationAction
  async authenticateFromLocalStorage() {
    api.setJWT(window.localStorage['token'])
    return {
      token: window.localStorage['token'],
      login: window.localStorage['login']
    }
  }
  @MutationAction
  async logOut() {
    delete window.localStorage['login']
    delete window.localStorage['token']
    api.clearJWT()
    return {
      token: '',
      login: ''
    }
  }
  @Action
  async register(user: User) {
    await axios({ method: 'post', url: `/api/User/Register?login=${user.login}&password=${user.password}` })
    this.authenticate(user)
  }
}
