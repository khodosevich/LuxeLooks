import React from 'react';
import {Box} from "@mui/material";
import {NavLink} from "react-router-dom";

const OrderItem = ({props}) => {
    return (
        <Box className="bag-element">
            <Box className="bag-element-img">
                <img style={{width: "80px", height: "80px", objectFit: "cover"}} src={props.imageUrl} alt=""/>
            </Box>
            <Box className="bag-element-description">
                <NavLink to={`/product/${props.id}`}>
                    <h3 className="bag-element-description__title">
                        {props.name}
                    </h3>
                </NavLink>
                <p className="bag-element-description__color">
                    Type: {props.type}
                </p>
            </Box>
            <h3 className="bag-element-price">
                {props.price}$
            </h3>
        </Box>
    );
};

export default OrderItem;