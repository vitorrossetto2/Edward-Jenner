import { Notfound } from '../../pages';
import { routes } from './routing';
import { setPrivateProperties } from '../_shared';

const privateProperties = new WeakMap();

export default class Router {
  constructor() {
    privateProperties.set(this, {
      id: 0,
    });
    window.onpopstate = () => {
      this.controlHistoryPopState();
    };
  }

  setContent(content = {}) {
    setPrivateProperties(privateProperties, this, { _content: content });
    this.getInitialRoute();
  }

  getInitialRoute() {
    let route = window.location.href.split('/#');
    if (route.length > 1) {
      this.routeChange(route[1], true);
    } else {
      this.routeChange('/', true);
    }
  }

  async routeChange(route = '', pop = false) {
    const { _content } = privateProperties.get(this);
    const component = routes.filter((x) => x.path === route);
    if (component.length > 0) {
      this.controlHistoryPushState(route, pop);
      if ('resolve' in component[0]) {
        try {
          const response = await component[0].resolve();
          _content.data(component[0].component, response);
        } catch (err) {
          console.log(err); // eslint-disable-line
          //_content.route(new PageError());
        }
      } else {
        _content.route(component[0].component);
      }
    } else {
      _content.route(new Notfound());
    }
  }

  controlHistoryPushState(route, pop) {
    const splitUrl = window.location.href.split('/#');
    if (route === '/') return window.location.href.split('/#')[0];
    let count = privateProperties.get(this)['id'] + 1;
    setPrivateProperties(privateProperties, this, { id: count });
    if (!pop) window.history.pushState({ route, id: count }, document.title, `${splitUrl[0]}#${route}`);
  }

  controlHistoryPopState() {
    const state = window.history.state;
    if (!state) this.routeChange('/');
    else this.routeChange(state.route, true);
  }
}
