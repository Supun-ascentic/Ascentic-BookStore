import * as React from 'react';
import './App.css';
import { Switch, Route, withRouter, RouteComponentProps, Link } from 'react-router-dom';
import Home from './components/Home';
import CreateBook from './components/book/Create';
import EditBooks from './components/book/EditBook';
import ViewBookDetails from './components/book/ViewBookDetails';

import { Layout} from 'antd';
import "antd/dist/antd.css";


const { Header, Content, Footer } = Layout;



class App extends React.Component<RouteComponentProps<any>> {
  public render() {
    return (
      <div>

        <Layout className="layout">
            <Header>
              <div className="logo" style={{color: "white"}}>Ascentic Book Store</div>
            </Header>
            <Content style={{ padding: '20px 50px',minHeight:800 }}>
            <Switch>
              <Route path={'/'} exact component={Home} />
              <Route path={'/create'} exact component={CreateBook} />
              <Route path={'/details/:id'} exact component={ViewBookDetails} />
              <Route path={'/edit/:id'} exact component={EditBooks} />
            </Switch>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
          </Layout>

      </div>
    );
  }
}
export default withRouter(App);