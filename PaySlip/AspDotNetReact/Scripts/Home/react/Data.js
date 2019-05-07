import React, { Component } from 'react';
import axios from 'axios';

export default class MVCData extends Component {

    constructor() {
        super();
        this.state = {
            Data: []
        };
    }

    componentDidMount() {
        axios.get('/Data/Index')
            .then(response => {
                //console.log(response.data);
                this.setState({ Data: response.data.result });
            })
            .catch(error => {
                console.log(error);
            });
    }

    render() {
        return (
            <section>
                <h1>Data List</h1>
                <div>
                    <table>
                        <thead><tr><th>Id</th><th>Name</th><th>Category</th></tr></thead>
                        <tbody>
                            {
                                this.state.Data.map((p, index) => {
                                    return <tr key={index}><td>{p.Id}</td><td> {p.Name}</td><td>{p.Company}</td></tr>;
                                })
                            }
                        </tbody>
                    </table>
                </div>
            </section>
        );
    }
}