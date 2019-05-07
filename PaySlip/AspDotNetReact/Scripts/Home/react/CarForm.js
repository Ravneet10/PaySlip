import React, { Component } from 'react';
import axios from 'axios';


export default class CarForm extends Component {

    constructor() {
        super();
        this.state = {
            Model: '',
            Make: '',
            VehicleType: '',
            Engine: '',
            WheelsCount: '',
            BodyType: '',
            NumberofDoors: '',
            PassengerSeats: '',
            Datasaved: false
        };
    }

    handleChange = e => {
        this.setState({ [e.target.name]: e.target.value });
    }

    handleSubmit = e => {

        e.preventDefault();


        var data = {

            Model: this.state.Model,
            Make: this.state.Make,
            VehicleType: this.props.vehicle,
            Engine: this.state.Engine,
            Wheelscount: this.state.WheelsCount,
            BodyType: this.state.BodyType,


        }
        var vehicleData = {
            NumberofDoors: this.state.NumberofDoors,
            PassengerSeats: this.state.PassengerSeats
        }


        axios.post('/Data/SaveCarData', { vehicleModelData: data, vehicleProperties: vehicleData })
            .then(response => {
                this.setState({ Datasaved: true });
                $("#successDiv").removeClass('hidden');
               
            })
            .catch(error => {
                console.log(error)
            });

    }

    componentDidMount() {

        this.setState({
            Model: '',
            Make: '',
            VehicleType: '',
            Engine: '',
            WheelsCount: '',
            BodyType: '',
            NumberofDoors: '',
            PassengerSeats: '',
            Datasaved: false
        });
    }

    render() {
        const requiredStyle = {
            color: 'red',
            fontsize: 'large'
        };
        return (
            <form className="mt-5" onSubmit={this.handleSubmit}>
                <h1>{this.props.vehicle} Form</h1>
                <div className="alert alert-success hidden" id="successDiv" >
                    <strong>Success! Data Saved Successfully.</strong>
                 </div>
                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Model: </label>
                    <input type="text" className="form-control" name="Model" value={this.Model} onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span> <label>Enter the {this.props.vehicle} Make: </label>
                    <input type="text" className="form-control" name="Make" value={this.Make} onChange={this.handleChange} required />
                </div>
                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Engine: </label>
                    <input type="text" className="form-control" name="Engine" value={this.Engine} onChange={this.handleChange} required />
                </div>
                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the vehicle type: </label>
                    <input type="text" className="form-control" disabled name="VehicleType" value={this.props.vehicle} onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Wheels: </label>
                    <input type="text" className="form-control" name="WheelsCount" value={this.WheelsCount} pattern="[0-9]*" onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} BodyType: </label>
                    <input type="text" className="form-control" name="BodyType" value={this.BodyType} onChange={this.handleChange} required />
                </div>
                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Seats Count: </label>
                    <input type="text" className="form-control" name="NumberofDoors" value={this.NumberofDoors} pattern="[0-9]*" onChange={this.handleChange} required />
                </div>
                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} door Count: </label>
                    <input type="text" className="form-control" name="PassengerSeats" value={this.PassengerSeats} pattern="[0-9]*" onChange={this.handleChange} required />
                </div>

                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        );
    }
}