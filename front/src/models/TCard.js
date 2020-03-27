export default class TButton {
  constructor(card = {}) {
    this.title = card.title || 'Title';
    this.body = card.body || 'Body card';
  }
}
