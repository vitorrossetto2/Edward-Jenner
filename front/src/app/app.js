import './app.scss';
import { Content, Header, Spinner } from '../components';
import { Router, setPrivateProperties } from '../@core';
import { STRINGS, setDelay } from '../utils';
import template from './template.js';

const privateProperties = new WeakMap();
window.router = new Router();
/**
 * @class App
 * @classdesc Componente principal
 * @constructs App
 */
export default class App {
  constructor(options = {}) {
    privateProperties.set(this, {
      _defaultSelector: 'app__raio__do__bem',
      _injectInto: options.injectInto || document.querySelector('body'),
    });

    this.renderCritical();
  }

  renderCritical() {
    // TODO - spinner
    const { _injectInto } = privateProperties.get(this);
    const name = STRINGS.PROJECT_IDENTIFY;

    _injectInto.innerHTML = template.app(name);
    this.el = _injectInto.querySelector(`#${name}`);

    const spinner = new Spinner();
    this.el.appendChild(spinner.render());
    spinner.show(true);
    setDelay(1000).then(() => {
      spinner.show(false);
    });
    window.spinner = spinner;
    // render spinner, after onload ok call render();
    this.render();
  }

  createChilds() {
    const { el } = this;
    const header = new Header();
    const content = new Content();
    setPrivateProperties(privateProperties, this, { _header: header, _content: content });
    [header.render(), content.render()].forEach((item) => el.appendChild(item));
  }

  /**
   * @description Este método é responsável por renderizar o projeto
   * @memberof App
   * @function render
   * @example var app = new App;
   * app.render();
   */
  render() {
    this.createChilds();
    const { _content } = privateProperties.get(this);
    window.router.setContent(_content);
  }
}
