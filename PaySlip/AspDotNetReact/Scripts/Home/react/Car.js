import React, { Component } from "react";
import CarForm from "./CarForm";
import VehicleForm from "./VehicleForm";
class Car extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Vehicle: "",
            option: [],
            showCarForm: false
        };
    }

    ChangeVehicle = e => {
        this.setState({ Vehicle: e.target.value });
        if (e.target.value == "") {
            this.setState({ showCarForm: false });
        }
        else {
            this.setState({ showCarForm: true });
        }
       
    };
    componentDidMount() {
        const optionsData = [
            { value: "", label: "--Select Vehicle--"},
            { value: "Car", label: "Car" },
            { value: "Scotter", label: "Scotter" }
        ];
        this.setState({ option: optionsData });

    }

    render() {

        return (

            <section>

                <div className="form-group mt-4 mb-4">
                    <h3> Please select the vehicle type::</h3>
                    <select className="form-control" onChange={this.ChangeVehicle.bind(this)}                >
                        {this.state.option.map(team => (
                            <option key={team.value} value={team.value}>
                                {team.label}
                            </option>
                        ))}
                    </select>
                   
                    {this.state.showCarForm && this.state.Vehicle == "Car" ? <CarForm vehicle={this.state.Vehicle} /> : this.state.showCarForm ? <VehicleForm vehicle={this.state.Vehicle} />:null}
                 
                </div>
            </section>
        );
    }
}

export default Car;