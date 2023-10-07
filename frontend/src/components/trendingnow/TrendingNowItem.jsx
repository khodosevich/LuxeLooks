import React from 'react';

const TrendingNowItem = ({props}) => {
    return (
        <div className="trending__content__item">
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
        </div>
    );
};

export default TrendingNowItem;