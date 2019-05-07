import React, { Component } from 'react';
import axios from 'axios';
import { Paper, withStyles, Grid, TextField, Button, FormControlLabel, Checkbox } from '@material-ui/core';
export default class PaySlip extends Component {

    constructor() {
        super();
        this.state = {
            firstName: '',
            lastName: '',
            annualSalary: '',
            superRate: '',
            salaryMonth: '',
            Data: [],
            monthList: [],
            paySlipGenerated: false
        };
    }


    handleChange = event => {

        this.setState({ [event.target.name]: event.target.value });
    }

    OnBlur = event => {
        if (event.target.value > 50) {
            alert("Please enter value between 1 and 50.");
        }
    }
    handleSubmit = event => {
        event.preventDefault();
        var employeeDetails = this.state;

        axios.post('/Data/GeneratePaySlip', employeeDetails).then(response => {
            console.log(JSON.stringify(response.data.result))
            this.setState({ Data: response.data.result, paySlipGenerated: true });
        })
            .catch(error => {
                console.log(error);
            });
    }

    componentDidMount() {
        const optionsData = [
            { value: "", label: "--Select Month--" },
            { value: "Jan", label: "January" },
            { value: "Feb", label: "February" },
            { value: "Mar", label: "March" },
            { value: "Apr", label: "April" },
            { value: "May", label: "May" },
            { value: "Jun", label: "June" },
            { value: "Jul", label: "July" },
            { value: "Aug", label: "August" },
            { value: "Sept", label: "September" },
            { value: "Oct", label: "October" },
            { value: "Nov", label: "November" },
            { value: "Dec", label: "December" },
        ];
        this.setState({ monthList: optionsData });
    }

    render() {
        const required = {
            color: "red"
        }
        const marginStyle = {
           
            padding: "30px"
        }
       
        return (
            <section>
                <form onSubmit={this.handleSubmit}>
                    
                    <h3>Pay Slip Generator</h3>
                    <Paper style={marginStyle}>
                       
                            <h5>Employee Info</h5>

                        <div className="row">
                               
                            <div className="col-xs-6 form-group">
                                <span style={required}>*</span><label>Please enter the first name(required): </label>
                                <input type="text" className="form-control" minLength="3" placeholder="First name" name="firstName" required value={this.firstName} onChange={this.handleChange} />

                            </div>
                            <div className="col-xs-6 ">
                                <span style={required}>*</span><label>Please enter the last name</label>
                                <input type="text" className="form-control" minLength="3" placeholder="Surname" name="lastName" required value={this.lastName} onChange={this.handleChange} />

                            </div>
                            <div className="col-xs-6 form-group">
                                <span style={required}>*</span><label>Please enter the annual salary</label>
                                <input type="text" className="form-control" minLength="3" placeholder="Annual Salary" pattern="[0-9]*" inputMode="numeric" required name="annualSalary" value={this.annualSalary} onChange={this.handleChange} />

                            </div>
                            <div className="col-xs-6 form-group">
                                <span style={required}>*</span><label>Please enter super rate (0%-50% inclusive)</label>

                                <input type="text" className="form-control" placeholder="Super Rate" name="superRate" pattern="[0-9]*" inputMode="numeric" required value={this.superRate} max="50"
                                    onChange={this.handleChange} onBlur={this.OnBlur} />

                            </div>
                            <div className="col-xs-6 form-group">
                                <span style={required}>*</span><label>Please select the salary month</label>
                                <select className="form-control" onChange={this.handleChange} name="salaryMonth">
                                    {this.state.monthList.map(team => (
                                        <option key={team.value} value={this.salaryMonth}>
                                            {team.label}
                                        </option>
                                    ))}
                                </select>
                            </div>
                           
                        </div>
                        <div className=" col-xs-4 form-group">
                            <button type="submit" className="btn btn-primary" data-toggle="popover" title="Click to generate payslip">Generate PaySlip</button>
                        </div>

                    </Paper>
                </form>

                <div className="table-responsive">
                    {this.state.paySlipGenerated ?
                        <table className="table table-hover table-bordered" cellSpacing="0">
                            <caption>PaySlip Generator</caption>
                            <thead>
                                <tr>
                                    <th className="table-secondary">Item</th>
                                    <th className="table-secondary">Employee Details</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr className="table-info">
                                    <td className="table-active">Employee</td>
                                    <td>{this.state.Data.FirstName}</td>
                                </tr>
                                <tr className="table-info">
                                    <td>Pay date</td>
                                    <td>{this.state.Data.PayPeriod}</td>
                                </tr>
                                <tr className="table-info">
                                    <td>Gross income</td>
                                    <td>{this.state.Data.GrossIncome}</td>
                                </tr>

                                <tr className="table-info">
                                    <td>Income Tax</td>
                                    <td>{this.state.Data.IncomeTax}</td>
                                </tr>

                                <tr className="table-info">
                                    <td>Net income</td>
                                    <td>{this.state.Data.NetIncome}</td>
                                </tr>
                                <tr className="table-info">
                                    <td>Super</td>
                                    <td>{this.state.Data.Super}</td>
                                </tr>
                            </tbody>
                        </table>
                        : null}
                </div>

            </section>
        );
    }
}