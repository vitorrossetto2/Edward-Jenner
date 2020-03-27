import './content.scss';
import { Component } from '../../@core';

const privateProperties = new WeakMap();

/**
 * @class Content
 * @classdesc component/class Content
 */
export default class Content extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__content',
    });
  }

  route(page) {
    const { el } = this;
    el.innerHTML = '';
    el.appendChild(page.render());
  }

  data(route, data) {
    route.dataCharger(data);
    this.route(route);
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', {
      class: _defaultSelector,
    });
    return this.el;
  }
}
