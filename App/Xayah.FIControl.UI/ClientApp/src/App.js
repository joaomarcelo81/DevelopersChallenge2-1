import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';

import { BankStatementData } from './components/BankStatementData';

import { Statement } from './components/Statement';
import { Accountlaunche } from './components/Accountlaunche';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>    
            <Route exact path='/' component={BankStatementData} />
            <Route path='/statement' component={Statement} />
            <Route path='/accountlaunche' component={Accountlaunche} />
            
      </Layout>
    );
  }
}
