import './education.scss';
import { Component } from '../../@core';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Education
 * @classdesc component/class Education
 */
export default class Education extends Component {
  constructor() {
    super();
    privateProperties.set(this, {
      _defaultSelector: 'c__education',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);

    this.el = this.template('div', { class: _defaultSelector }, template.education());
    return this.el;
  }
}
