import React, {useContext, useEffect, useState} from 'react';

import './sidebar.css'
import {MyContext} from "../../App";
import {NavLink, useLocation} from "react-router-dom";

const SideBar = () => {

    const [activeItem, setActiveItem] = useState("");
    const location = useLocation()

    const handleItemClick = (item) => {
        setActiveItem(item);
    }

    const {user,setUser} = useContext(MyContext)

    const logout = () => {
        setUser({
            token: "",
            username: "",
            email:"",
            isAuthenticated: false,
        })

        localStorage.removeItem("token")
    }

    useEffect(() => {
        setActiveItem(location.pathname.substring(9))
    }, [user,location]);

    return (
        <div className="account-component__menu">
            <NavLink to="/account/profileinfo" className={`account-menu__item item1 ${activeItem === 'profileinfo' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item1')}>
                My Profile
            </NavLink>
            <NavLink to="/account/bag" className={`account-menu__item  item2 ${activeItem === 'bag' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item2')}>
                My bag
            </NavLink>
            <NavLink to="/account/myorders" className={`account-menu__item  item4 ${activeItem === 'myorders' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item4')}>
                My order
            </NavLink>
            <NavLink to="#" onClickCapture={logout} className={`account-menu__item  item3 ${activeItem === 'item3' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item3')}>
                Sign up
            </NavLink>
        </div>
    );
};

export default SideBar;