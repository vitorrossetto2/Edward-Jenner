export default {
  address(_defaultSelector, _address) {
    return `
        <div class="container">
          <div class="${_defaultSelector}__content">
            <div class="c__input">
              <select 
                class="c__input__field"
                name="type"
                tabindex="1"
                value="${_address.type}">
                <option value="0">Casa</option>
                <option value="1">Trabalho</option>
                <option value="2">Outro</option>
              </select>              
              <label class="c__input__label">Tipo:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="cep"                                 
                tabindex="1" 
                maxlength="9"
                value="${_address.cep}"/>
              <label class="c__input__label">CEP:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="street"                                 
                tabindex="2" 
                required
                pattern=".*\\S.*"
                value="${_address.street}"/>
              <label class="c__input__label">Rua/Avenida:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="number"                                 
                tabindex="3" 
                required
                pattern=".*\\S.*"
                value="${_address.number}"/>
              <label class="c__input__label">Número:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="complement"                                 
                tabindex="5" 
                required
                pattern=".*\\S.*"
                value="${_address.complement}"/>
              <label class="c__input__label">Complemento:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="neighborhood"                                 
                tabindex="6" 
                required
                pattern=".*\\S.*"
                value="${_address.neighborhood}"/>
              <label class="c__input__label">Bairro:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="state"                                 
                tabindex="7" 
                required
                pattern=".*\\S.*"
                value="${_address.state}"/>
              <label class="c__input__label">Estado:</label>
            </div>
            <div class="c__input">
              <input 
                class="c__input__field" 
                type="text" 
                name="country"                                 
                tabindex="8" 
                required
                pattern=".*\\S.*"
                value="${_address.country}"/>
              <label class="c__input__label">País:</label>
            </div>
            <button class="c__button c__button--reverse" type="button" disabled tabindex="9">Salvar</button>
          </div>
        </div>
      `;
  },
};
