import React from 'react';

import './categories.css'

import img1 from "../../assets/image.png"
import img2 from "../../assets/image-2.png"
import img3 from "../../assets/image-3.png"
import {NavLink} from "react-router-dom";


const Categories = () => {
    return (
        <div className="categories">
            <div className="categories-container">
                <div className="categories-content">
                    <div className="categories__items">
                        <div className="categories__item">
                            <NavLink to="/women">
                                <img className="categories__item__img" src={img1} alt="Women’s"/>
                                <h4 className="categories__item__title">
                                    Women’s
                                </h4>
                            </NavLink>

                        </div>
                        <div className="categories__item">
                            <NavLink to="/man">
                                <img className="categories__item__img" src={img2} alt="Women’s"/>
                                <h4 className="categories__item__title">
                                    Man’s
                                </h4>
                            </NavLink>
                        </div>
                        <div className="categories__item">
                            <NavLink to="/girls">
                                <img className="categories__item__img" src={img3} alt="Women’s"/>
                                <h4 className="categories__item__title">
                                    Kids’s
                                </h4>
                            </NavLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Categories;