import React, {useContext, useEffect, useState} from 'react';
import classes from "../../App.module.css"
import links from "./links.json"

import "./header.css"
import {Link, Navigate, NavLink, useLocation, useNavigate} from "react-router-dom";
import cardBag from "../../assets/cart1.svg";
import {MyContext} from "../../App";
import {method} from "../../api/methods";


const Header = () => {

    const [searchState,setSearchState] = useState("");

    const handlerSearchInput = (e) => {
        setSearchState(e.target.value)
    }

    const {user,setUser} = useContext(MyContext)

    let navigate = useNavigate();

    useEffect(() => {

    }, [user]);

    const location = useLocation();
    const renderHeaderCondition =  location.pathname !== "/";


    const search = async () => {
       const data = await method.getProductByName(searchState)
        setSearchState("")
        navigate(`/product/${data.id}`)
    }


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
                    <div className="search-input">
                        <input value={searchState} onChange={handlerSearchInput} className="input_header" type="text" placeholder="Search for products..."/>
                        <i onClick={search} className="fa" aria-hidden="true"></i>
                    </div>

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