import React from 'react';

import './popularcategory.css'
import tshirt from '../../assets/tshirt.svg'
import cat from '../../assets/cap.svg'
import shirt from '../../assets/shirt.svg'
import jacket from '../../assets/jacket.svg'


const PopularCategory = () => {
    return (
        <div className="popular-category">
            <div className="popular-category__container">
                <div className="popular-category__content">
                    <h3 className="popular-category__title">Popular categories</h3>
                    <div className="popular-category__items">
                        <div className="popular-category__item">
                            <img src={tshirt} alt="t-shirt"/>
                            <h3 className="popular-category__item-subtitle">T-shirt</h3>
                        </div>
                        <div className="popular-category__item">
                            <img src={cat} alt="t-shirt"/>
                            <h3 className="popular-category__item-subtitle">Cat</h3>
                        </div>
                        <div className="popular-category__item">
                            <img src={shirt} alt="t-shirt"/>
                            <h3 className="popular-category__item-subtitle">Shirt</h3>
                        </div>
                        <div className="popular-category__item">
                            <img src={tshirt} alt="t-shirt"/>
                            <h3 className="popular-category__item-subtitle">T-shirt</h3>
                        </div>
                        <div className="popular-category__item">
                            <img src={cat} alt="t-shirt"/>
                            <h3 className="popular-category__item-subtitle">Cat</h3>
                        </div>
                        <div className="popular-category__item">
                            <img src={jacket} alt="t-shirt"/>
                            <h3 className="popular-category__item-subtitle">Jacket</h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default PopularCategory;