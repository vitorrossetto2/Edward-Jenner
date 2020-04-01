import { setPrivateProperties } from '../@core';

const privateProperties = new WeakMap();
export default class THeader {
  constructor(logged = false) {
    privateProperties.set(this, {
      _logged: logged,
    });
    this.buildItems();
  }

  set logged(logged = false) {
    setPrivateProperties(privateProperties, this, { _logged: logged });
    this.buildItems();
    return;
  }

  buildItems() {
    const { _logged } = privateProperties.get(this);
    if (!_logged) this.items = dontLogged;
    else this.items = logged;
  }
}

const logged = [
  {
    name: 'Perfil',
    icon: 'icon-user-outline',
    route: 'profile',
  },
  {
    name: 'Listas',
    icon: 'icon-basket-3',
    route: 'list',
  },
  {
    name: 'Mapa',
    icon: 'icon-map-o',
    route: 'map',
  },
];

const dontLogged = [
  {
    name: 'Educação',
    icon: 'icon-book-open',
    route: 'education',
  },
  {
    name: 'Cadastro',
    icon: 'icon-user-add-outline',
    route: 'register',
  },
  {
    name: 'Login',
    icon: 'icon-login-1',
    route: 'login',
  },
];
