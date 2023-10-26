import React from 'react';


import inst1 from "../../assets/inst1.png"
import inst2 from "../../assets/inst2.png"
import inst3 from "../../assets/inst3.png"

import '@fortawesome/fontawesome-free/css/all.min.css';

import './followinst.css'
import {NavLink} from "react-router-dom";

const FollowInstagram = () => {
    return (
        <div className="follow">
            <div className="follow-container">
                <div className="follow-content">
                    <div className="info__follow">
                        <p className="info__follow-label">
                            Follow us on Instagram
                        </p>
                        <h3 className="info__follow-title">
                            @luxelooks
                        </h3>
                        <NavLink to="https://github.com/khodosevich/LuxeLooks">
                            <button className="info__follow-btn">
                                <i className="fab fa-instagram"></i>
                                Follow instagram
                            </button>
                        </NavLink>
                    </div>
                    <div className="images__inst">
                        <img src={inst1} alt=""/>
                        <img src={inst2} alt=""/>
                        <img src={inst3} alt=""/>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default FollowInstagram;