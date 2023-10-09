import React from 'react';
import {NavLink} from "react-router-dom";

const TrendingNowItem = ({props}) => {
    return (
        <div className="trending__content__item">
            <NavLink to = {`/product/${props.id}`}>
                <div className="trending__content__item-img">
                    <img style={{width:"400px" , height:"400px"}} src={props.imageUrl} alt="Shirt"/>
                </div>
                <div className="trending__content__item-description">
                    <h4 className="trending__content__item-title">
                        {props.name}
                    </h4>
                    <p className="trending__content__item-price">
                        ${props.price}
                    </p>
                </div>
            </NavLink>
        </div>
    );
};

export default TrendingNowItem;