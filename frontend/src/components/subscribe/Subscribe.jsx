import React, {useState} from 'react';

import subscribe from "../../assets/subscribe.png"

import './subscribe.css'
import { method} from "../../api/methods";

const Subscribe = () => {

    const [dataToSubscribe, setDataToSubscribe] = useState({
        Category:"",
        Email:""
    })

    const [activeIndex, setActiveIndex] = useState(-1);

    const handleButtonClick = (index) => {
        setActiveIndex(index);

        switch (index){
            case 0:
                setDataToSubscribe(prev => ({...prev, Category:"Mens"}))
                break
            case 1:
                setDataToSubscribe(prev => ({...prev, Category:"Womens"}))
                break;
            case 2: case 3:
                setDataToSubscribe(prev => ({...prev, Category:"Kids"}))
                break;
        }
    };

    const [isChecked, setIsChecked] = useState(false);

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
    };


    const inputHandler = (e) => {
        setDataToSubscribe(prev => ({
            ...prev,
            Email:e.target.value
        }))

    }

    const updateInput = () => {

        if(dataToSubscribe.Email && dataToSubscribe.Category && isChecked){
            method.subscribe(dataToSubscribe);
            alert("all is good")

            setDataToSubscribe({
                Category:"",
                Email:""
            })

            setActiveIndex(-1);
            setIsChecked(false);

        }else {
            alert("check your data")
        }

    }

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
                                <input value={dataToSubscribe.Email} onChange={inputHandler} placeholder='Your working email' className="subscribe__info-email__input" type="text"/>
                                <button onClick={updateInput} className="subscribe__info-email__button">
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