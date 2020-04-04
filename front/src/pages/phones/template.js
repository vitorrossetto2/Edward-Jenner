export default {
  phones(_defaultSelector, _phone) {
    return `
        <div class="container">
          <div class="${_defaultSelector}__content">
            <div class="c__input">
              <select 
                class="c__input__field"
                name="type"
                tabindex="1"
                value="${_phone.type}">
                <option value="0">Casa</option>
                <option value="1">Celular</option>                
              </select>              
              <label class="c__input__label">Tipo:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="ddd"           
                tabindex="1" 
                maxlength="2"
                required
                pattern=".*\\S.*"
                value="${_phone.ddd}"/>
              <label class="c__input__label">DDD:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="number"                                 
                tabindex="2" 
                required
                pattern=".*\\S.*"
                value="${_phone.number}"/>
              <label class="c__input__label">Número:</label>
            </div>
            <button class="c__button c__button--reverse" type="button" disabled tabindex="9">Salvar</button>
          </div>
        </div>
      `;
  },
};
