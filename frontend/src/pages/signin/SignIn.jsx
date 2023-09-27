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


    const signInRequest = async () => {


       const person = await method.login(localState)

         setUser({
             token: person.token,
             username: person.username,
             isAuthenticated: true,
         });


        setLocalSate({
            Password: "",
            UserName: ""
        })

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
                                    <TextField value={user.UserName} onChange={loginChange} id="outlined-basic" label="Username" variant="outlined" />
                                    <TextField value={user.Password} type="password" onChange={passwordChange}  id="outlined-basic" label="Password" variant="outlined" />
                                </div>

                                <Button onClick={signInRequest} variant="contained">SignIn</Button>

                                <NavLink className="exist-account" to="/registration">
                                    Registration
                                </NavLink>

                            </div>
                        </div>
                    </div>
            }
        </>



    );
};

export default SignIn;