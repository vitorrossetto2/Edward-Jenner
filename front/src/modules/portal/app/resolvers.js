import { STRINGS } from '../../../utils';

const resolveUser = async () => {
  return new Promise((resolve) => {
    window.spinner?.show(true);
    setTimeout(() => {
      resolve(JSON.parse(localStorage.getItem(STRINGS.PROJECT_IDENTIFY)));
      window.spinner.show(false);
    }, 1000);
  });
};

export { resolveUser };
