import React, { Component } from 'react';
//import List from "../lib/List";

export class Orders extends Component {
    displayName = Orders.name

    constructor(props) {
      super(props);
      this.state = { orders: [], loading: true };

      fetch('api/order')
          .then(response => response.json())
          .then(data => {
              this.setState({ orders: data, loading: false });
          });
    }

    renderOrders = orders => {
        return (
            orders.map(order =>
                <ul key={order.orderId}>
                    <ui>{order.productId}</ui>
                    :
                    <ui>{order.productAmount}</ui>
                </ul>
            )
        )
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderOrders(this.state.orders);

        return (
            <div>
                <h1>All Orders!!</h1>
                {contents}
            </div>
        );
    }

   }
    
