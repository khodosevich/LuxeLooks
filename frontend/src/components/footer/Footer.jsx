import React from 'react';
import './footer.css'
import {NavLink} from "react-router-dom";

import heart from "../../assets/outline.svg"

const Footer = () => {
    return (
        <div className="footer">
            <div className="footer__container">
                <div className="footer__items">
                    <div className="footer__item">
                        <ul className="footer__menu__item">
                            <li className="footer__menu__item__link footer__menu__item__title ">help</li>
                            <li className="footer__menu__item__link">Delivery & returns</li>
                            <li className="footer__menu__item__link">FAQ</li>
                            <li className="footer__menu__item__link">Track order</li>
                            <li className="footer__menu__item__link">Contacts</li>
                            <li className="footer__menu__item__link">Blog</li>
                        </ul>
                    </div>

                    <div className="footer__item">
                        <ul className="footer__menu__item">
                            <li className="footer__menu__item__link footer__menu__item__title ">Shop</li>
                            <li className="footer__menu__item__link">New arrivals</li>
                            <li className="footer__menu__item__link">Trending now</li>
                            <li className="footer__menu__item__link">Sales</li>
                            <li className="footer__menu__item__link">Brands</li>
                        </ul>
                    </div>

                    <div className="footer__item">
                        <ul className="footer__menu__item">
                            <li className="footer__menu__item__link footer__menu__item__title ">Get in touch</li>
                            <li className="footer__menu__item__subtitle">Call: <NavLink to="#" className="footer__contact">(405) 555-0128</NavLink> </li>
                            <li className="footer__menu__item__subtitle">Email: <NavLink to="#" className="footer__contact">hello@createx.com</NavLink> </li>
                        </ul>
                    </div>

                </div>

                <div className="footer__rules">
                    <p className="footer__rules__title">© All rights reserved. Made with</p>
                    <img src={heart} alt="heart"/>
                    <p className="footer__rules__title">by Matvey and Alexey 150503</p>
                </div>

            </div>
        </div>
    );
};

export default Footer;