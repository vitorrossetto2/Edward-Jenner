import './notfound.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();

/**
 * @class Notfound
 * @classdesc component/class Notfound
 */
export default class Notfound extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__notfound',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.notfound());
    return this.el;
  }
}
