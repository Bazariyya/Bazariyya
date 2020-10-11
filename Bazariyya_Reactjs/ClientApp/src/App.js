import './assets/style/primereact.css';
import './assets/style/flags.css';
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './pages/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ProductList } from './pages/product/product_list';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={ProductList} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
