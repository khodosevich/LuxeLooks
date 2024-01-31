import React, {useContext, useEffect, useState} from 'react';

import './sidebar.css'
import {MyContext} from "../../App";
import { NavLink} from "react-router-dom";
import {method} from "../../api/methods";



const SideBar = () => {

    const [activeItem, setActiveItem] = useState('item1');

    const handleItemClick = (item) => {
        setActiveItem(item);
    }

    const [searchState,setSearchState] = useState("");

    const {user,setUser} = useContext(MyContext)

    const logout = () => {

        // method.revoke({name:user.username ,token: user.token})

        setUser({
            token: "",
            username: "",
            email:"",
            isAuthenticated: false,
        })

        localStorage.removeItem("token")

    }

    useEffect(() => {

    }, [user]);

    return (

        <div className="account-component__menu">
            <ul className="account-menu__items">
                <NavLink to="/account/profileinfo" className={`account-menu__item item1 ${activeItem === 'item1' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item1')}>
                    My Profile
                </NavLink>
                <NavLink to="/bag" className={`account-menu__item  item2 ${activeItem === 'item2' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item2')}>
                    My bag
                </NavLink>
                <NavLink to="/account/myorders" className={`account-menu__item  item4 ${activeItem === 'item4' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item4')}>
                    My order
                </NavLink>
                <NavLink to="#" onClickCapture={logout} className={`account-menu__item  item3 ${activeItem === 'item3' ? 'active__account-menu' : ''}`} onClick={() => handleItemClick('item3')}>
                    Sign up
                </NavLink>
            </ul>
        </div>
    );
};

export default SideBar;