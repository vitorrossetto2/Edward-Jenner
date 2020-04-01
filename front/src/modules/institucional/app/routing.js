import { Education, Home, Login, Register } from '../../../pages';

const routes = [
  {
    path: '',
    page: Home,
  },
  {
    path: 'education',
    page: Education,
  },
  {
    path: 'home',
    page: Home,
  },
  {
    path: 'login',
    page: Login,
  },
  {
    path: 'register',
    page: Register,
  },
];

export { routes };
