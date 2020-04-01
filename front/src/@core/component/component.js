import { createElement, getChildsElements, setElementStateChange } from '../_shared';

const privateProperties = new WeakMap();

export default class Component {
  constructor(props = {}) {
    privateProperties.set(this, {
      _state: props,
      _elements: {},
    });
  }

  get state() {
    return privateProperties.get(this)['_state'];
  }

  set state(state) {
    setElementStateChange(privateProperties, this, state);
  }

  template(tag = 'div', attrs = {}, childs) {
    const el = createElement(tag, attrs, childs);
    getChildsElements(el, privateProperties, this);
    return el;
  }
}
