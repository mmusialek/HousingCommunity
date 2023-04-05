import { Outlet } from 'react-router';
import { Layout } from '../components/Layout';

export const MainPage = () => {
  return (
    <Layout>
      <Outlet />
    </Layout>
  );
};
