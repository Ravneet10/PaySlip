import React, { Component } from 'react';
import { render } from 'react-dom';
import { BrowserRouter as Router, Route, Link, Switch } from 'react-router-dom';
import { Redirect } from 'react-router-dom';
import createHistory from 'history/createBrowserHistory';

import Login from './LogIn'


export default class Nav extends Component {

    constructor(props) {
        super(props);

        this.state = {
            signIn: false,
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }




    handleSubmit() {

        const history = createHistory();

        history.push('/welcome');
    }

    render() {

        return (

            <div>
                <div id="mainWrapper">

                    <Router history={history} >
                        <div>
                            
                            <Route path="/login" render={(props) => (<Login submit={this.handleSubmit} />)} />
                           
                        </div>
                    </Router>
                </div>
            </div>
        )

    }
}