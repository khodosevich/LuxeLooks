import React, {useContext, useState} from 'react';

import './login.css'
import {Button, TextField} from "@mui/material";
import {Navigate, NavLink} from "react-router-dom";
import {method} from "../../api/methods";
import {MyContext} from "../../App";

const Registration = () => {


    const {user,setUser} = useContext(MyContext);

    const [localState, setLocalState] = useState({
        UserName: "",
        Password: "",
        Email:""
    });

    const loginRequest = async () => {


        // console.log(localState)

        const person = await method.register(localState)

        setUser({
            token: person.token,
            username: person.username,
            email: person.email,
            isAuthenticated: true,
        });


        setLocalState({
            UserName: "",
            Password: "",
            Email:""
        })
    }

    const loginChange = (e) => {

        setLocalState(prev => ({
            ...prev,
            UserName: e.target.value
        }))
    }

    const passwordChange = (e) => {
        setLocalState(prev => ({
            ...prev,
            Password: e.target.value
        }))
    }

    const emailChange = (e) => {
        setLocalState(prev => ({
            ...prev,
            Email: e.target.value
        }))

    }


    return (

        <>

            {
                user.isAuthenticated
                    ? <Navigate to="/"/>
                    : <div className="registration">
                        <div className="registration__container">
                            <div className="registration-content">

                                <h3>Sign Up</h3>

                                <div className="inputs__registration">
                                    <TextField onChange={loginChange}  label="Username" type="text"  variant="outlined" />
                                    <TextField onChange={passwordChange}  type="password" label="Password" variant="outlined" />
                                    <TextField onChange={emailChange}  label="Email" type="email" variant="outlined" />
                                </div>

                                <Button onClick={loginRequest} variant="contained">Registration</Button>

                                <NavLink className="exist-account" to="/signin">
                                    exist account? SignIN
                                </NavLink>

                                <NavLink className="exist-account" to="/">
                                    На главную
                                </NavLink>
                            </div>
                        </div>
                    </div>
            }

        </>
    );
};

export default Registration;