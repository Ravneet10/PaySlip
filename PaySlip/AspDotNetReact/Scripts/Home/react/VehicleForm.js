import React, { Component } from 'react';
import axios from 'axios';




export default class Vehicleform extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Model: '',
            Make: '',
            VehicleType: '',
            Engine: '',
            WheelsCount: '',
            BodyType: '',
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
            BodyType: this.state.BodyType
        }
       

        axios.post('/Data/SaveData',  data)
            .then(response => {
                this.setState({ Datasaved: true })
                $("#successDiv").removeClass('hidden');
                
            })
            .catch(error => {
                console.log(error)
            })
            

    }

    componentDidMount() {


        this.setState({
            Model: '',
            Make: '',
            VehicleType: '',
            Engine: '',
            WheelsCount: '',
            BodyType: '',
            Datasaved: false
        });
    }

    render() {
        const requiredStyle = {
            color: 'red',
            fontsize: 'large'
        };
       
        return (
            <form className="mt-5" onSubmit={this.handleSubmit} id=""tset>
                <div className="alert alert-success hidden" id="successDiv" >
                    <strong>Success! Data Saved Successfully.</strong>
                </div>
             
                
                <h1>{this.props.vehicle} Form</h1>
                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Model: </label>
                    <input type="text" className="form-control" name="Model" value={this.Model} onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span> <label>Enter the {this.props.vehicle} Make: </label>
                    <input type="text" className="form-control" name="Make" value={this.Make} onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the Vehicle Type: </label>
                    <input type="text" className="form-control" disabled name="VehicleType" value={this.props.vehicle} onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Engine: </label>
                    <input type="text" className="form-control"  name="Engine" value={this.Engine} onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} Wheels count: </label>
                    <input type="text" className="form-control" name="WheelsCount" value={this.WheelsCount} pattern="[0-9]*" onChange={this.handleChange} required />
                </div>

                <div className="form-group">
                    <span style={requiredStyle}>*</span><label>Enter the {this.props.vehicle} BodyType: </label>
                    <input type="text" className="form-control" name="BodyType" value={this.BodyType} onChange={this.handleChange} required />
                </div>
               
                

                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        );
    }
}