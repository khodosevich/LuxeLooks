import React from 'react';

import './login.css'
import {Button, TextField} from "@mui/material";
import {NavLink} from "react-router-dom";

const Registration = () => {



    return (
        <div className="registration">
            <div className="registration__container">
                <div className="registration-content">

                    <h3>Sign Up</h3>

                    <div className="inputs__registration">
                        <TextField id="outlined-basic" label="Username" variant="outlined" />
                        <TextField id="outlined-basic" type="password" label="Password" variant="outlined" />
                        <TextField id="outlined-basic" label="Email" variant="outlined" />
                    </div>

                    <Button variant="contained">Registration</Button>

                    <NavLink className="exist-account" to="/signIn">
                        exist account? SignIN
                    </NavLink>
                </div>
            </div>
        </div>
    );
};

export default Registration;