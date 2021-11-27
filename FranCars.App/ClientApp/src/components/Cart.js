import React, { Component } from "react";
import { withRouter } from 'react-router';

class Cart extends Component {
    state = { loading: true};

    async componentDidMount() {
        console.log(`id cart: ${this.props.match.params.id}`)
        const response = await fetch(
            `http://localhost:18350/shoppingCart/userId=${this.props.match.params.id}`
        );
        const content = await response.json();
        this.setState(Object.assign({ loading: false }, content));
    }

    render () {
        if(this.state.loading) {
            return <h2>loading ... </h2>;
        }

        const {
            numberOfItems,
            shoppingItems,
            totalAmount
        } = this.state;

        if(numberOfItems === 0) {
            return(
                <h2>Your cart is empty!</h2>
            )
        } else {
            return(
                <div>
                    <h4>Your cart</h4>
                    <table className='table table-striped' aria-labelledby="tableLabel">
                        <thead>
                          <tr>
                            <th>Item Name</th>
                            <th>Price</th>
                          </tr>
                        </thead>
                        <tbody>
                          {shoppingItems.map(shoppingItem =>
                            <tr key={shoppingItem.id}>
                              <td>{shoppingItem.productName}</td>
                              <td>{shoppingItem.price}</td>
                            </tr>
                          )}
                        </tbody>
                    </table>
                    <button className="w-100 btn btn-lg btn-primary">Checkout ({totalAmount})</button>
                </div>
            )
        }
    }
}

export default withRouter(Cart);