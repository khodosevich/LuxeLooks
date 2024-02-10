import React, {useContext, useState} from 'react';

import './login.css'
import {Button, TextField} from "@mui/material";
import {Navigate, NavLink} from "react-router-dom";
import {method} from "../../api/methods";
import {MyContext} from "../../App";
import OwnAlert from "../../components/alert/OwnAlert";
import jwtDecode from "jwt-decode";

const Registration = () => {


    const {user,setUser} = useContext(MyContext);

    const [validationErrors, setValidationErrors] = useState({
        username: '',
        password: '',
        email: '',
    });

    const [alertData, setAlertData] = useState({
        isOpen:false,
        type:"",
        statusText:""
    });

    const [localState, setLocalState] = useState({
        UserName: "",
        Password: "",
        Email:""
    });

    const [showAlert, setShowAlert] = useState(false);
    const [infoAlert, setInfoAlert] = useState({type:"" , statusText:""})

    const validateForm = () => {
        let isValid = true;
        const errors = {};

        if (!localState.UserName) {
            errors.username = 'Username is required';
            isValid = false;
        }

        if (!localState.Password) {
            errors.password = 'Password is required';
            isValid = false;
        }

        if (!localState.Email) {
            errors.email = 'Email is required';
            isValid = false;
        } else if (!/\S+@\S+\.\S+/.test(localState.Email)) {
            errors.email = 'Invalid email address';
            isValid = false;
        }

        if (!isValid) {
            setInfoAlert( {type:"error" ,statusText:"Validation error!"} )

            setShowAlert(true);
        }

        setValidationErrors(errors);
        return isValid;
    };




    const loginRequest = async () => {
        const isValid = validateForm();

        try {

            if(isValid) {
                const person = await method.register(localState);

                setUser({
                    token: person.token,
                    username: person.username,
                    email: person.email,
                    isAuthenticated: true,
                });

                setLocalState({
                    UserName: "",
                    Password: "",
                    Email: ""
                });

                setAlertData({
                    isOpen: true,
                    type: 'success',
                    statusText: 'Successfully logged in!'
                });

               localStorage.setItem("token",JSON.stringify(person.token));

            }

        } catch (error) {

            if (error.response && error.response.status === 400) {
                setInfoAlert( {type:"error" ,statusText:error.response.data} )
                setShowAlert(true);
                console.error("Ошибка: Некорректные данные", error.response.data);
            }
        }
    };


    const loginChange = (e) => {
        setShowAlert(false)
        setLocalState(prev => ({
            ...prev,
            UserName: e.target.value
        }))
    }

    const passwordChange = (e) => {
        setShowAlert(false)
        setLocalState(prev => ({
            ...prev,
            Password: e.target.value
        }))
    }

    const emailChange = (e) => {
        setShowAlert(false)
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
                            {showAlert && (
                                <OwnAlert props={infoAlert} />
                            )}
                            <div className="registration-content">
                                <h3>Sign Up</h3>
                                <div className="inputs__registration">
                                    <TextField
                                        onChange={loginChange}
                                        label="Username"
                                        type="text"
                                        variant="outlined"
                                        error={Boolean(validationErrors.username)}
                                        helperText={validationErrors.username}
                                    />
                                    <TextField
                                        onChange={passwordChange}
                                        type="password"
                                        label="Password"
                                        variant="outlined"
                                        error={Boolean(validationErrors.password)}
                                        helperText={validationErrors.password}
                                    />
                                    <TextField
                                        onChange={emailChange}
                                        label="Email"
                                        type="email"
                                        variant="outlined"
                                        error={Boolean(validationErrors.email)}
                                        helperText={validationErrors.email}
                                    />
                                </div>
                                <Button onClick={loginRequest} variant="contained">Registration</Button>
                                <NavLink className="exist-account" to="/signin">
                                    Exist account?
                                </NavLink>
                                <NavLink className="exist-account" to="/">
                                    On main
                                </NavLink>
                            </div>
                        </div>
                    </div>
            }
        </>
    );
};

export default Registration;