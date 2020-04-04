/* eslint-disable */
import { ELEMENT_NODE, DOCUMENT_NODE } from '../_shared';
const CACHE_ELEMENTS = {};

const memoizeDOMManipulation = (rootElement = document, query = 'querySelectorAll', selector = '') => {
  const stringSelector = `${rootElement}[${query}](${selector})`;

  if (
    typeof rootElement === 'object' &&
    rootElement.nodeType &&
    (rootElement.nodeType === ELEMENT_NODE || rootElement.nodeType === DOCUMENT_NODE)
  ) {
    if (CACHE_ELEMENTS[stringSelector] !== undefined) {
      return CACHE_ELEMENTS[stringSelector];
    } else {
      const result = rootElement[query](selector);
      if (!result) return false;
      CACHE_ELEMENTS[stringSelector] = result;
      return result;
    }
  } else {
    throw Error(`Don't find query: ${stringSelector.toString()}`);
  }
};

export { memoizeDOMManipulation };
