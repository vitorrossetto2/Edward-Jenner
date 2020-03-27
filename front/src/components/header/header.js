import './header.scss';
import { Component } from '../../@core';
import { THeader } from '../../models';
import template from './template.js';

const privateProperties = new WeakMap();
const model = new THeader();
/**
 * @class Header
 * @classdesc component/class Header
 */
export default class Header extends Component {
  constructor() {
    super();

    privateProperties.set(this, {
      _defaultSelector: 'c__header',
      _items: model.items,
    });
  }

  getChilds() {
    const { _defaultSelector } = privateProperties.get(this);
    const { el } = this;

    this.btnDropdown = el.querySelector(`.${_defaultSelector}__control__navigation`);
    this.navigation = el.querySelector(`.${_defaultSelector}__navigation`);
    this.btnDropdown.onclick = (evt) => {
      evt.preventDefault();
      this.controlNavigation();
    };

    el.querySelector(`.${_defaultSelector}__logotipo`).onclick = (evt) => {
      evt.preventDefault();
      window.router?.routeChange('home');
    };

    Array.from(this.navigation.querySelectorAll('a'))?.forEach((item) => {
      item.onclick = (evt) => {
        evt.preventDefault();
        const route = evt.target.getAttribute('href')?.replace('#', '');
        window.router?.routeChange(route);
        this.controlNavigation();
      };
    });
  }

  controlNavigation() {
    const { navigation } = this;
    const { _defaultSelector } = privateProperties.get(this);

    navigation?.classList.toggle(`${_defaultSelector}__navigation--open`);
  }

  render() {
    const { _defaultSelector, _items } = privateProperties.get(this);
    this.el = this.template(
      'nav',
      {
        class: _defaultSelector,
      },
      template.header(_defaultSelector, _items)
    );
    window.header = this;
    this.getChilds();
    return this.el;
  }
}
