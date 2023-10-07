import React from 'react';

import img1 from "../../../assets/bag.png"

import './bagelement.css'

const BagElement = ({props}) => {

    console.log(props)
    return (
        <div className="bag-element">
            <div className="bag-element-img">
                <img style={{width:"150px" , height:"150px", objectFit:"cover" , borderRadius:"200px"}} src={props.imageUrl} alt=""/>
            </div>
            <div className="bag-element-description">
                <h3 className="bag-element-description__title">
                    {props.name}
                </h3>
                <p className="bag-element-description__color">
                    Color: pink
                </p>
                <p className="bag-element-description__size">
                    Size: S
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