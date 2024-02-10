import React from 'react';
import './bagelement.css'
import {NavLink} from "react-router-dom";

const BagElement = ({props , removeProductFromCart}) => {

    const removeFromCart = async () => {
        removeProductFromCart(props.id)
    }

    return (
        <div className="bag-element">
                <div className="bag-element-img">
                    <img style={{width:"80px" , height:"80px", objectFit:"cover" }} src={props.imageUrl} alt=""/>
                </div>
                <div className="bag-element-description">
                    <NavLink to={`/product/${props.id}`}>
                        <h3 className="bag-element-description__title">
                            {props.name}
                        </h3>
                    </NavLink>
                    <p className="bag-element-description__color">
                        Type: {props.type}
                    </p>
                </div>
                <h3 className="bag-element-price">
                    {props.price}$
                </h3>
            <button onClick={removeFromCart} className="bag-element-btn__delete">
                Delete
            </button>
        </div>
    );
};

export default BagElement;