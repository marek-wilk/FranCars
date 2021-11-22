import React, { Component } from 'react';
import { withRouter } from 'react-router-dom'
import Map from './Map'


class Details extends Component {
    state = { loading: true};

    async componentDidMount() {
        const response = await fetch(
            `http://localhost:18350/vehicle/${this.props.match.params.id}`
        );
        const json = await response.json();
        this.setState(Object.assign({ loading: false }, json));
    }

    render() {
        if(this.state.loading) {
            return <h2>loading ... </h2>;
        }

        const {
            make,
            model,
            yearModel,
            price,
            locationName,
            longitude,
            latitude,
            warehouseName
        } = this.state;

        return (
            <div className="details">
                <div>
                    <h2>{make} {model}</h2>
                    <h4>Year of production: {yearModel}</h4>
                    <h4>Stored in: {warehouseName}</h4>
                    <div id="map">
                        <Map 
                        latitude={latitude} 
                        longitude={longitude}
                        location={locationName}
                        warehouseName={warehouseName}/>
                    </div>
                </div>
            </div>
        );
    }
}

export default withRouter(Details);