import './breadcrumb.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Breadcrumb
 * @classdesc component/class Breadcrumb
 */
export default class Breadcrumb extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__breadcrumb',
    });
  }

  handleClick() {
    const { el } = this;
    el.querySelector('button').onclick = (evt) => {
      evt.preventDefault();
      window.history.back();
    };
  }

  render(config = {}) {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.breadcrumb(_defaultSelector, config));
    this.handleClick();
    return this.el;
  }
}
