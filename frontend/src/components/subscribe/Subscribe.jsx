import React, {useState} from 'react';

import subscribe from "../../assets/subscribe.png"

import './subscribe.css'

const Subscribe = () => {

    const [activeIndex, setActiveIndex] = useState(1);

    const handleButtonClick = (index) => {
        setActiveIndex(index);
    };

    const [isChecked, setIsChecked] = useState(false);

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
    };

    return (
        <div className="subscribe">
            <div className="subscribe-container">
                <div className="subscribe-content">
                    <div className="subscribe__info">
                        <h3 className="subscribe__info-title">
                            Subscribe for updates
                        </h3>
                        <p className="subscribe__info-subtitle">
                            Subscribe for exclusive early sale access and new arrivals.
                        </p>
                        <div className="subscribe__info-choice">
                            <button
                                onClick={() => handleButtonClick(0)}
                                className={`subscribe__info-choice__btn ${activeIndex === 0 ? 'active' : ''}`}
                            >
                                Women
                            </button>
                            <button
                                onClick={() => handleButtonClick(1)}
                                className={`subscribe__info-choice__btn ${activeIndex === 1 ? 'active' : ''}`}
                            >
                                Man
                            </button>
                            <button
                                onClick={() => handleButtonClick(2)}
                                className={`subscribe__info-choice__btn ${activeIndex === 2 ? 'active' : ''}`}
                            >
                                Boys
                            </button>
                            <button
                                onClick={() => handleButtonClick(3)}
                                className={`subscribe__info-choice__btn ${activeIndex === 3 ? 'active' : ''}`}>
                                Girls
                            </button>
                        </div>
                        <div className="subscribe__info-email">
                            <p className="subscribe__info-email__title">
                                Email
                            </p>
                            <div className="subscribe__info-email__btn">
                                <input placeholder='Your working email' className="subscribe__info-email__input" type="text"/>
                                <button className="subscribe__info-email__button">
                                    Subscribe
                                </button>
                            </div>
                        </div>
                        <div className="subscribe__info-checkbox__agree">
                            <input
                                className="subscribe__info-checkbox"
                                checked={isChecked}
                                onChange={handleCheckboxChange}
                                type="checkbox"/>
                            I agree to receive communications from LuxeLooks Store.
                        </div>
                    </div>
                    <div className="subscribe__img">
                        <img src={subscribe} alt=""/>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Subscribe;