const loadPolyfills = () => {
  if (!String.prototype.normalize) {
    String.prototype.normalize = function () {
      return this;
    };
  }

  (function (arr) {
    arr.forEach((item) => {
      if (item.hasOwnProperty.call('remove')) {
        return;
      }
      Object.defineProperty(item, 'remove', {
        configurable: true,
        enumerable: true,
        writable: true,
        value: function remove() {
          if (this.parentNode === null) {
            return;
          }
          this.parentNode.removeChild(this);
        },
      });
    });
  })([Element.prototype, CharacterData.prototype, DocumentType.prototype]);

  if (/*@cc_on!@*/ false || !!document.documentMode) {
    if (window.Element && !Element.prototype.closest) {
      Element.prototype.closest = function (s) {
        let matches = (this.document || this.ownerDocument).querySelectorAll(s);
        let i;
        let el = this;
        do {
          i = matches.length;
          while (--i >= 0 && matches.item(i) !== el) {
            continue;
          }
        } while (i < 0 && (el = el.parentElement));
        return el;
      };
    }
  }
};

export { loadPolyfills };
