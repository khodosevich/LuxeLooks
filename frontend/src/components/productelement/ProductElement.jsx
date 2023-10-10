import React from 'react';

import style from './productElement.module.css'
import {NavLink} from "react-router-dom";

const ProductElement = (props) => {
    return (
        <div className={style.product__element}>
            <NavLink to={`/product/${props.props.id}`}>
                <img className={style.product__element__img} src={props.props.imageUrl} alt=""/>
                <h4 style={{
                    color:"#424551",
                    fontFamily: "Lato",
                    fontSize: "18px",
                    fontWeight: "400",
                    lineHeight: "150%"
                }}>
                    {
                        props.props.name
                    }
                </h4>
                <p style={{
                    color:"#1E212C",
                    fontFamily: "Lato",
                    fontSize: "24px",
                    fontStyle: "normal",
                    fontWeight: "700",
                    lineHeight: "130%",
                    margin:"0"
                }}>
                    ${props.props.price}
                </p>
            </NavLink>
        </div>
    );
};

export default ProductElement;