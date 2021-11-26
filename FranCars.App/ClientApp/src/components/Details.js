import React, { Component } from 'react';
import { withRouter } from 'react-router';
import { Link } from 'react-router-dom'
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
        const addItemToCart = async () => {
            await fetch(`http://localhost:18350/shoppingCart/addItem`, {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({
                    id, 
                    make, 
                    model, 
                    price
                })
            })
        }

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
            warehouseName,
            id = this.props.id
        } = this.state;

        const renderButton = () => {
            console.log(`id at details: ${id}`)
            if(id === 0) {
                return (
                    <Link to="/login">Please login to continue shopping</Link>
                )
            } else {
                return (
                    <button className="w-20 btn btn-lg btn-primary" onClick={() => addItemToCart(id, make, model, price)}>Add to cart {price}</button>
                )
            }
        }

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
                {renderButton()}
            </div>
        );
    }
}

export default withRouter(Details);