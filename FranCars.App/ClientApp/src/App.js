import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Vehicles from './components/Vehicles';
import Details from './components/Details';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/'>
          <Vehicles />
        </Route>
        <Route path='/details/:id'>
          <Details />
        </Route>
      </Layout>
    );
  }
}
