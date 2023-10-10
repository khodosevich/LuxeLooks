import React from 'react';


import './bagelement.css'
import {NavLink} from "react-router-dom";

const BagElement = ({props}) => {


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

                <div className="bag-element-amount">
                    <select className="select__element" name="filter_31">
                        <option value="V1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                    </select>
                </div>

                <h3 className="bag-element-price">
                    {props.price}$
                </h3>



            <button className="bag-element-btn__delete">
                Delete
            </button>

        </div>
    );
};

export default BagElement;