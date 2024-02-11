import React from 'react';

import style from './productElement.module.css'
import {NavLink} from "react-router-dom";
import {Box, Typography} from "@mui/material";

const ProductElement = (props) => {
    return (
        <Box className={style.product__element}>
            <NavLink to={`/product/${props.props.id}`}>
                <img className={style.product__element__img} src={props.props.imageUrl} alt=""/>
                <h4 style={{
                    color:"#424551",
                    fontFamily: "Montserrat",
                    fontSize: "18px",
                    fontWeight: "400",
                    padding:"0 5px",
                    minHeight:"32px"
                }}>
                    {
                        props.props.name.charAt(0).toUpperCase() + props.props.name.toString().toLowerCase().slice(1)
                    }
                </h4>
                <Typography variant={"body1"}  sx={{
                    color:"#1E212C",
                    fontFamily: "Montserrat",
                    fontSize: "18px",
                    fontStyle: "normal",
                    fontWeight: "700",
                    padding:"10px",
                    textAlign:"end"
                }}>
                    ${props.props.price}
                </Typography>
            </NavLink>
        </Box>
    );
};

export default ProductElement;