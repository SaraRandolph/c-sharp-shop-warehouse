import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Orders  from './components/OrdersList';

export default () => (
  <Layout>
    <Route path='/' component={Orders} />
  </Layout>
);
