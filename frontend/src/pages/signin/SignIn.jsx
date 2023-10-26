import React, {useContext, useMemo, useState} from 'react';

import './signin.css'
import {Button, TextField} from "@mui/material";
import {method} from "../../api/methods";
import {MyContext} from "../../App";
import {Navigate, NavLink} from "react-router-dom";
import OwnAlert from "../../components/alert/OwnAlert";


const SignIn = () => {

    const {user, setUser} = useContext(MyContext)

    const [localState,setLocalSate] = useState({
        Password: "",
        UserName: ""
    });

    const [validationError, setValidationError] = useState({
        UserName: "",
        Password: ""
    });

    const [showAlert, setShowAlert] = useState(false);
    const [infoAlert, setInfoAlert] = useState({type:"" , statusText:""})

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

        if (!isValid) {
            setInfoAlert( {type:"error" ,statusText:"Validation error!"} )

            setShowAlert(true);
        }

        return isValid;
    };

    const signInRequest = async () => {
        const isValid = validateForm();

        if (isValid) {
            try {
                const person = await method.login(localState);

                setUser({
                    token: person.token,
                    username: person.username,
                    email: person.email,
                    isAuthenticated: true,
                });

                setLocalSate({
                    Password: "",
                    UserName: ""
                });
            } catch (error) {
                if (error.response && error.response.status === 400) {
                    setInfoAlert( {type:"error" ,statusText:error.response.data} )
                    setShowAlert(true);
                    console.error("Ошибка: Некорректные данные", error.response.data);
                } else {
                    setInfoAlert( {type:"error" ,statusText: error.message} )
                    setShowAlert(true);
                    console.error("Произошла ошибка:", error.message);
                }
            }
        }
    };




    useMemo(() => {
    }, [user]);

    const loginChange = (e) => {
        setShowAlert(false)
        setLocalSate(prev => ({
            ...prev,
            UserName: e.target.value
        }))
    }

    const passwordChange = (e) => {
        setShowAlert(false)
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

                            {showAlert && (
                                <OwnAlert props={infoAlert} />
                            )}


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
                                    On main
                                </NavLink>
                            </div>
                        </div>
                    </div>
            }
        </>

    );
};

export default SignIn;