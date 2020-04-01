export default {
  spinner(_defaultSelector) {
    return `            
      <div class="${_defaultSelector}__content">
        <svg class="${_defaultSelector}__content__circular" viewBox="25 25 50 50">
          <circle
            class="path"
            cx="50"
            cy="50"
            r="20"
            fill="none"
            strokewidth="2"
            strokemiterlimit="10">
          </circle>
        </svg>        
      </div>
    `;
  },
};
