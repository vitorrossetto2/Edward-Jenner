import './what.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();

/**
 * @class What
 * @classdesc component/class What
 */
export default class What extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__what',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.what());
    return this.el;
  }
}
