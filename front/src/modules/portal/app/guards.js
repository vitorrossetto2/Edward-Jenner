import { STRINGS } from '../../../utils';

const userIsLogged = () => {
  const user = JSON.parse(localStorage.getItem(STRINGS.PROJECT_IDENTIFY));
  if (user) return user;
  return false;
};

export { userIsLogged };
