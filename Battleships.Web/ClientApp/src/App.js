import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import BattleshipsComponent from "./components/BattleshipsComponent";

export default () => (
  <Layout>
    <Route exact path='/' component={BattleshipsComponent} />
  </Layout>
);
