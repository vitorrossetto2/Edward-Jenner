const createElement = (tag = 'div', attrs = {}, inner = '') => {
  try {
    const el = document.createElement(tag);

    for (const [k, v] of Object.entries(attrs)) {
      el.setAttribute(k, v);
    }

    createChilds(el, inner);
    return el;
  } catch (err) {
    console.log(err); // eslint-disable-line
    return false;
  }
};

const createChilds = (el, inner) => {
  if (Array.isArray(inner)) {
    inner.forEach((component) => {
      el.appendChild(component);
    });
    return;
  }

  if (typeof inner === 'string') {
    el.innerHTML = inner;
    return el;
  }

  if (typeof inner === 'object' && !inner.nodeType) {
    el.innerHTML = inner.html;
    inner.reference.forEach((item, index) => {
      const anchor = el.querySelector(item);
      if (inner.components[index]) {
        anchor.parentElement.appendChild(inner.components[index]);
        anchor.remove();
      }
    });
    return el;
  }

  if (typeof inner === 'object' && inner.nodeType && inner.nodeType === Node.ELEMENT_NODE) {
    el.appendChild(inner);
    return el;
  }
};

export { createElement };
