import React, { Component } from "react";


export class List extends Component {

    renderButton = () => {
            return (
                <button type="submit"
                    name="processOrder"
                    className="btn btn-default">
                    PROCESS
                </button>
            );
        }
    }

    renderListItem = item => {
        let {
            id,
            listTitle,
            listProductAmount,
            dateProcessed
        } = this.props;

        return (
            <div key={item[id]} className="list-item">
                <div className="list-group-item" key={item[id]}>
                    <div className="list-info-container">
                        <div className="list-info-details">
                            <div className="list-title">
                                {item[listTitle]}  {item[listProductAmount] ? 'Product Amount: ' + item[listProductAmount] : null}
                            </div>
                            <div className="status">
                                {item[dateProcessed] ? this.renderButton : "Order Not Processed"}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    render() {
        let { items } = this.props;
        if (items.length < 1) {
            return (
                <div>
                    "Loading..."
                </div>
            );
        }
        let activeItems = items.map(item => this.renderListItem(item));
        return (
            <div className="list-group">
                {activeItems}
            </div>
        );
    }
}
