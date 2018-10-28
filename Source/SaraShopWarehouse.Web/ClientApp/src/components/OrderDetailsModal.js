import React, { Component } from "react";
import { bindActionCreators } from 'redux';
import { connect } from "react-redux";
import { Field, reduxForm } from "redux-form";
import { actionCreators } from '../store/WeatherForecasts';

class OrderDetailsModal extends Component {
    constructor(props) {
        super(props);

    }

     renderTitle() {
        return (
            <div>
                <h4 className="modal-title">
                    {this.props.title}
                </h4>
            </div>
        );
    }

    renderCancelButton() {
        return (
            <button type="button"
                onClick={this.props.onSave}
                name="cancelButton"
                className="btn btn-default pull-right">
                CANCEL
			</button>
        );
    }

    renderSaveButton() {
        return (
            <button type="button"
                // onClick={this.updateOrder}
                name="updateOrder"
                className="btn btn-primary pull-right">
                SAVE
			</button>
        );
    }

    render() {
        console.log(this.props);
        let { order } = this.props;

       return (
           <div className="row">
                {this.renderTitle()}
               <form className="modal">
                   <div className="body-content-partial">
                       <h1> Product Id = {order.productName} </h1>
                        <div className="form-group">
                            <div className="field-label">
                                Product Name
                            </div>
                            <div>
                               <Field
                                   label="productName"
                                   name="productName"
                                   component="input"
                                   value={order.productName}
                               />
                            </div>
                       </div>
                       <div className="form-group">
                           <div className="field-label">
                               Product Description
                            </div>
                           <div>
                               <Field
                                   label="productDescription"
                                   name="productDescription"
                                   component="input"
                               />
                           </div>
                       </div>
                        
                    </div>
                </form>
            </div>
        );
    }
}


export default reduxForm({
    form: "OrderDetailsForm"
})(OrderDetailsModal);


