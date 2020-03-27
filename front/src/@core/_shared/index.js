import { COMMENT_NODE, DOCUMENT_FRAGMENT_NODE, DOCUMENT_NODE, ELEMENT_NODE, TEXT_NODE } from './HTMLNodeTypes';

import { getChildsElements, setElementStateChange, setPrivateProperties } from './controlPrivateProperties';

import { createElement } from './controlDOM';

export {
  ELEMENT_NODE,
  TEXT_NODE,
  COMMENT_NODE,
  DOCUMENT_NODE,
  DOCUMENT_FRAGMENT_NODE,
  getChildsElements,
  setPrivateProperties,
  setElementStateChange,
  createElement,
};
