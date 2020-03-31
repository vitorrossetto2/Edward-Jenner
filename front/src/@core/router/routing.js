import { Education, Home, Login, Map, Nearby, Register, Welcome } from '../../pages';
import { resolveUser } from './resolvers';

const routes = [
  {
    path: '',
    component: new Home(),
  },
  {
    path: 'education',
    component: new Education(),
  },
  {
    path: 'home',
    component: new Home(),
  },
  {
    path: 'login',
    component: new Login(),
  },
  {
    path: 'register',
    component: new Register(),
  },
  {
    path: 'welcome',
    component: new Welcome(),
    resolve: resolveUser,
  },
  {
    path: 'nearby',
    component: new Nearby(),
  },
  {
    path: 'map',
    component: new Map(),
  },
];

export { routes };
