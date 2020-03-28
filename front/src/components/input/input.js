import './input.scss';
import { Component } from '../../@core';
import { TInput } from '../../models';
import template from './template.js';

const privateProperties = new WeakMap();
/**
 * @class Input
 * @classdesc component/class Input
 */
export default class Input extends Component {
  constructor(options = {}) {
    super(new TInput(options));
    privateProperties.set(this, {
      _defaultSelector: 'c__input',
    });
  }

  render() {
    const { _defaultSelector } = privateProperties.get(this);
    const { label, pattern, type, required } = this.state;

    this.el = this.template(
      'div',
      {
        class: _defaultSelector,
      },
      template.input(_defaultSelector, label, pattern, type, required)
    );
    return this.el;
  }
}
