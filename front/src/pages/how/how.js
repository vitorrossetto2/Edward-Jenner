import './how.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class How
 * @classdesc component/class How
 */

export default class How extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__how',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.how());
    return this.el;
  }
}
