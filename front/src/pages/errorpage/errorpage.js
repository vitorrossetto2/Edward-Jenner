import './errorpage.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Errorpage
 * @classdesc component/class Errorpage
 */
export default class ErrorPage extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__errorpage',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.errorpage(_defaultSelector));
    return this.el;
  }
}
