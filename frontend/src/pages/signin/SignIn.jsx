import React, {useContext, useMemo, useState} from 'react';

import './signin.css'
import {Button, TextField} from "@mui/material";
import {method} from "../../api/methods";
import {MyContext} from "../../App";
import {Navigate, NavLink} from "react-router-dom";


const SignIn = () => {

    const {user, setUser} = useContext(MyContext)

    const [localState,setLocalSate] = useState({
        "Password": "",
        "UserName": ""
    });

    const [validationError, setValidationError] = useState({
        UserName: "",
        Password: ""
    });

    const validateForm = () => {
        let isValid = true;
        const updatedErrors = { UserName: "", Password: "" };

        if (localState.UserName.length < 3) {
            updatedErrors.UserName = "Username must be least 3 symbols";
            isValid = false;
        }

        if (localState.Password.length <= 4) {
            updatedErrors.Password = "Password must be at least 5 symbols";
            isValid = false;
        }

        setValidationError(updatedErrors);

        return isValid;
    };


    const signInRequest = async () => {

        const isValid = validateForm();

        if (isValid) {

            const person = await method.login(localState)

            setUser({
                token: person.token,
                username: person.username,
                email: person.email,
                isAuthenticated: true,
            });


            setLocalSate({
                Password: "",
                UserName: ""
            })
        }

    }

    useMemo(() => {
        console.log(user)
    }, [user]);

    const loginChange = (e) => {

        setLocalSate(prev => ({
            ...prev,
            UserName: e.target.value
        }))
    }

    const passwordChange = (e) => {
        setLocalSate(prev => ({
            ...prev,
            Password: e.target.value
        }))
    }

    return (
        <>
            {
                user.isAuthenticated ?
                    <Navigate to="/"/>
                    :
                    <div className="signin">
                        <div className="signin__container">
                            <div className="signin-content">

                                <h3>Sign In</h3>

                                <div className="inputs__signin">
                                    <TextField value={user.UserName} onChange={loginChange} id="outlined-basic" label="Username" variant="outlined"
                                               error={!!validationError.UserName}
                                               helperText={validationError.UserName}
                                    />
                                    <TextField value={user.Password} type="password" onChange={passwordChange}  id="outlined-basic" label="Password" variant="outlined"
                                               error={!!validationError.Password}
                                               helperText={validationError.Password}
                                    />
                                </div>

                                <Button onClick={signInRequest} variant="contained">SignIn</Button>

                                <NavLink className="exist-account" to="/registration">
                                    Registration
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

export default SignIn;