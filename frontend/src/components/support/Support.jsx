import React from 'react';

import delivery from "../../assets/ic-delivery.svg"
import credit from "../../assets/ic-credit-card.svg"
import shield from "../../assets/ic-shield.svg"
import callcenter from "../../assets/ic-call-center.svg"

import "./support.css"

const Support = () => {
    return (
        <div className="support">
            <div className="support__container">
                <div className="support__content">
                    <div className="support__support__items">
                        <div className="support__support__item">
                            <img src={delivery} alt="delivery"/>
                            <h4 className="support__support__item-title">Fast Worldwide Shipping</h4>
                            <p className="support__support__item-description">Get free shipping over $250</p>
                        </div>
                        <div className="support__support__item">
                            <img src={callcenter} alt="delivery"/>
                            <h4 className="support__support__item-title">24/7 Customer Support</h4>
                            <p className="support__support__item-description">Friendly 24/7 customer support</p>
                        </div>
                        <div className="support__support__item">
                            <img src={shield} alt="delivery"/>
                            <h4 className="support__support__item-title">Money Back Guarantee</h4>
                            <p className="support__support__item-description">We return money within 30 days</p>
                        </div>
                        <div className="support__support__item">
                            <img src={credit} alt="delivery"/>
                            <h4 className="support__support__item-title">Secure Online Payment</h4>
                            <p className="support__support__item-description">Accept all major credit cards</p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    );
};

export default Support;