import React, {useContext, useEffect, useState} from 'react';
import classes from "../../App.module.css"
import links from "./links.json"

import "./header.css"
import {Link, NavLink, useLocation} from "react-router-dom";
import cardBag from "../../assets/cart1.svg";
import {MyContext} from "../../App";
import Search from "../search/Search";


const Header = () => {

    const {user,setUser} = useContext(MyContext)

    useEffect(() => {

    }, [user]);

    const location = useLocation();
    const renderHeaderCondition =  location.pathname !== "/";

    return (
        <div className={`${renderHeaderCondition ? 'header black' : 'header'}`}>
            <div className={classes.container}>
                <div className="navbar">
                    <div className="logo-container">
                        <Link className="logo" to="/">LuxeLooks</Link>
                    </div>
                    <div className="client-menu">
                        <ul className="menu">
                            {links.map((element,index) => (
                                <li key={index} className={element.class}>
                                    <NavLink to={element.to}>{element.name}</NavLink>
                                </li>
                            ))}
                        </ul>
                    </div>
                    <Search/>
                    <div className="bag">
                        <NavLink to="/bag">
                            <img className="shop__cart" src={cardBag} alt="cart"/>
                        </NavLink>
                    </div>
                    {
                        user.isAuthenticated
                            ? <div className="account">
                            <NavLink to="/account/profileinfo" >
                                <button className="login-btn">
                                    Account
                                </button>
                            </NavLink>
                             </div>
                            : <div className="account">
                                <NavLink to="/signin">
                                    <button  className="login-btn">
                                             login
                                    </button>
                                </NavLink>
                            </div>
                    }
                </div>
            </div>
        </div>
    );
};

export default Header;