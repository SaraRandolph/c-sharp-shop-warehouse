import React, { Component } from "react";
import { Field, reduxForm } from "redux-form";

class OrderDetailsModal extends Component {
    constructor(props) {
        super(props);
        this.state = {
          
        }
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
        let { order } = this.props;

       return (
            <div>
                {this.renderTitle()}
                <form className="modal-form">
                   <div className="body-content-partial">
                       <h1> Product Id = {order.productId} </h1>
                        <div className="form-group">
                            <div className="field-label">
                                Product Name
                            </div>
                            <div>
                               <Field
                                   label="productName"
                                   name="productName"
                                   component="input"
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



export default OrderDetailsModal({
    form: 'simple' 
})(OrderDetailsModal)
