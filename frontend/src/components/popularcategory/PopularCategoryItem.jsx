import React from 'react';
import cat from "../../assets/cap.svg";
import {NavLink} from "react-router-dom";

const PopularCategoryItem = ({props}) => {
    return (
        <NavLink to="#" className="popular-category__item">
            <img className="popular-category__item-img" src={props.imageUrl} alt="t-shirt"/>
            <h3 className="popular-category__item-subtitle">{props.type}</h3>
        </NavLink>
    );
};

export default PopularCategoryItem;