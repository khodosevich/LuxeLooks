import React from 'react';

import './trending.css'

import img4 from '../../assets/img4.png'
import img5 from '../../assets/img5.png'
import right from '../../assets/Right.svg'
import left from '../../assets/Left.svg'


const TrendingNow = () => {
    return (
        <div className="trending-now">
            <div className="trending__container">
                <div className="trending__content">
                    <div className="trending__title">
                        <h3>Trending Now</h3>
                        <div className="pagination">
                            <div className="img__bg">
                                <img src={left} alt="left"/>
                            </div>
                          <div className="img__bg">
                              <img src={right} alt="right"/>
                          </div>
                        </div>
                    </div>
                    <div className="trending__content__items">
                        <div className="trending__content__item">
                            <div className="trending__content__item-img">
                                <img src={img4} alt="Shirt"/>
                            </div>
                            <div className="trending__content__item-description">
                                <h4 className="trending__content__item-title">
                                    Shirt with insertion lace trims
                                </h4>
                                <p className="trending__content__item-price">
                                    $49.95
                                </p>
                            </div>
                        </div>
                        <div className="trending__content__item">
                            <div className="trending__content__item-img">
                                <img src={img5} alt="Shirt"/>
                            </div>
                            <div className="trending__content__item-description">
                                <h4 className="trending__content__item-title">
                                    Check coat with colour contrast
                                </h4>
                                <p className="trending__content__item-price">
                                    $183.45
                                </p>
                            </div>
                        </div>
                        <div className="trending__content__item">
                            <div className="trending__content__item-img">
                                <img src={img4} alt="Shirt"/>
                            </div>
                            <div className="trending__content__item-description">
                                <h4 className="trending__content__item-title">
                                    Shirt with insertion lace trims
                                </h4>
                                <p className="trending__content__item-price">
                                    $49.95
                                </p>
                            </div>
                        </div>
                    </div>

                    <div className="btns__trending">
                        <button className="btn__trending" >
                            Explore top sales
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default TrendingNow;