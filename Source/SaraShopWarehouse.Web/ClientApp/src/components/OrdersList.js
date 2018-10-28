import React, { Component } from 'react';
import Modal from 'react-modal';
import { connect } from 'react-redux';
import OrderDetailsModal from "./OrderDetailsModal";
import axios from "axios";

class Orders extends Component {
    displayName = Orders.name

    constructor(props) {
      super(props);
        this.state = {
            orders: [],
            loading: true,
            modalOpen: false,
            order: {}
        };

      fetch('api/order')
          .then(response => response.json())
          .then(data => {
              this.setState({ orders: data, loading: false });
          });
    }

    processOrder = (id) => {
        
        console.log(id);

    }

    getOrderInfo = order => {
        this.setState({ order: order, openModal: true });
    }

    closeModal () {
        this.setState({ order: {}, openModal: false });
    }

    renderProcessButton = order => {
        return (
            <button
                type="submit"
                onClick={this.processOrder}
                name="processOrder"
                className="btn btn-primary">
                PROCESS ORDER
            </button>
            )
    }


    renderOrders = orders => {
        
        return (
            <table className="table table-striped">
                <thead className="thead-dark">
                    <tr>
                        <th scope="col">Order Id</th>
                        <th scope="col">Product Name</th>
                        <th scope="col">Product Description</th>
                        <th scope="col">Order Type</th>
                        <th scope="col">Amount Ordered</th>
                        <th scope="col">Date Processed</th>
                    </tr>
                </thead>
                <tbody>
                    {orders.map(order =>
                        <tr onClick={() => this.getOrderInfo(order)}> 
                            <td>{order.id ? order.id : null}</td>
                            <td>{order.productName ? order.productName : null}</td>
                            <td>{order.productDescription ? order.productDescription : null}</td>
                            <td>{order.orderType == 0 ? "Receipt" : "Invoice"}</td>
                            <td>{order.productAmount ? order.productAmount : null}</td>
                            <td>{order.proccessedAt ? order.proccessedAt : this.renderProcessButton(order)}</td>
                        </tr>
                    )}
                </tbody>
            </table>
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
               <Modal isOpen={this.state.openModal} onClose={this.closeModal}>
                    <OrderDetailsModal title="Order Details" bsSize="large" aria-labelledby="contained-modal-title-lg" order={this.state.order} />
               </Modal>
            </div>
        );
    }

}
export default Orders;

