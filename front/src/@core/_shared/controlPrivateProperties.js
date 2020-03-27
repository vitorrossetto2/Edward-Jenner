const setPrivateProperties = (weakMap, instance, newProperties = {}) => {
  return weakMap.set(instance, { ...weakMap.get(instance), ...newProperties });
};

const getChildsElements = (el, weakMap, instance) => {
  const { _elements, _state } = weakMap.get(instance);
  for (const k of Object.keys(_state)) {
    const element = el.querySelectorAll(`[data-prop-${k}]`);
    if (element) {
      _elements[`_element${k}`] = element;
      setPrivateProperties(weakMap, instance, { _elements });
    }
  }
};

const setElementStateChange = (weakMap, instance, newState = {}) => {
  const { _state, _elements } = weakMap.get(instance);

  if (JSON.stringify(_state) === JSON.stringify(newState)) return false;

  const changeElement = (k, v) => {
    if (!_elements[`_element${k}`]) return;
    Array.from(_elements[`_element${k}`]).forEach((item) => {
      item.innerHTML = v;
    });
  };

  for (const [k, v] of Object.entries(newState)) {
    if (!_state[k]) {
      _state[k] = v;
    }

    if (_state[k] && typeof _state[k] !== 'object' && _state[k] !== v) {
      _state[k] = v;
      changeElement(k, v);
    }
  }

  setPrivateProperties(weakMap, instance, { ..._state });
};

export { setPrivateProperties, getChildsElements, setElementStateChange };
