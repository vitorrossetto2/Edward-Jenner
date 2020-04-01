import { ErrorPage, Notfound } from '../../pages';
import { setPrivateProperties } from '../_shared';

const privateProperties = new WeakMap();

export default class Router {
  constructor(routes = []) {
    privateProperties.set(this, {
      id: 0,
      _routes: routes,
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
    let route = window.location.href.split('#');
    if (route.length > 1) {
      this.routeChange(route[1], true);
    } else {
      this.routeChange('', true);
    }
  }

  async routeChange(route = '', pop = false) {
    const { _content, _routes } = privateProperties.get(this);
    const component = _routes.find((x) => x.path === route);
    let page = new Notfound();

    if (!component) return _content.route(new Notfound());

    this.controlHistoryPushState(route, pop);

    if ('guard' in component) {
      page = await this.applyGuard(component);
    } else if ('resolve' in component) {
      page = await this.applyResolve(component);
    } else {
      page = new component.page();
    }

    if (!page) {
      _content.route(new ErrorPage());
      return;
    }
    _content.route(page);
  }

  async applyResolve(component) {
    try {
      const response = await component.resolve();
      return new component.page(response);
    } catch (err) {
      console.log(err); // eslint-disable-line
      return false;
      //_content.route(new PageError());
    }
  }

  async applyGuard(component) {
    const { _routes } = privateProperties.get(this);
    try {
      if (!component.guard()) {
        window.location.href = _routes.find((x) => x.path === '**').page;
        return false;
      }
      if ('resolve' in component) {
        return await this.applyResolve(component);
      }
      return new component.page();
    } catch (err) {
      console.log(err); // eslint-disable-line
      return false;
    }
  }

  controlHistoryPushState(route, pop) {
    const splitUrl = window.location.href.split('#');

    if (route === '/') return window.location.href.split('#')[0];

    let count = privateProperties.get(this)['id'] + 1;
    setPrivateProperties(privateProperties, this, { id: count });

    if (!pop) window.history.pushState({ route, id: count }, document.title, `${splitUrl[0]}#${route}`);
  }

  controlHistoryPopState() {
    const state = window.history.state;
    if (!state) this.routeChange('');
    else this.routeChange(state.route, true);
  }
}
