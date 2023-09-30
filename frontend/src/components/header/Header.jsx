import React, {useContext, useEffect, useState} from 'react';
import classes from "../../App.module.css"
import links from "./links.json"

import "./header.css"
import {Link, NavLink} from "react-router-dom";
import cardBag from "../../assets/cart.svg";
import {MyContext} from "../../App";


const Header = () => {

    const [searchState,setSearchState] = useState("");

    const handlerSearchInput = (e) => {
        console.log(e.target.value)
    }

    const {user,setUser} = useContext(MyContext)

    const logout = () => {

        setUser({
            token: "",
            username: "",
            isAuthenticated: false,
        })
    }

    useEffect(() => {

    }, [user]);

    return (
        <div className="header">
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
                    <div className="search-input">
                        <input onChange={handlerSearchInput} className="input_header" type="text" placeholder="Search for products..."/>
                        <i className="fa" aria-hidden="true"></i>
                    </div>
                    <div className="bag">
                        <NavLink to="/bag">
                            <img className="shop__cart" src={cardBag} alt="cart"/>
                        </NavLink>
                        <span className="after__cart">0</span>
                    </div>


                    {
                        user.isAuthenticated
                            ? <div className="account">
                                <button onClick={logout} className="login-btn">
                                       logout
                                </button>
                             </div>
                            : <div className="account">
                                <NavLink to="/registration">
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