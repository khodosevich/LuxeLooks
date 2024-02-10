import React, {Fragment, useCallback, useContext, useEffect, useState} from "react";
import { useNavigate } from "react-router-dom"
import {MyContext} from "../../App";
import jwtDecode from "jwt-decode";
import jwt_decode from "jwt-decode";


const AuthGuard = (props) => {
    const { children } = props;

    const navigate = useNavigate()

    const {user, setUser} = useContext(MyContext)

    const [checked, setChecked] = useState(false);

    const check = useCallback(async () => {
        if (!localStorage.getItem("token")) {
            navigate("/")
            setUser(prev => {
                return {
                    ...prev,
                    isAuthenticated: false
                }
            })
        } else {
            try{
                const token = JSON.parse(localStorage.getItem("token"))
                const decoded = jwt_decode(token);

                console.log(decoded)

                if(decoded.exp)

                setChecked(true)
                setUser(prev => {
                    return {
                        ...prev,
                        id: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
                        username: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
                        email:decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
                        isAuthenticated: true,
                        token:token
                    }
                })

            }catch(e) {
                console.log(e)
            }

        }
    }, [user.isAuthenticated]);

    useEffect(() => {
        check();
    }, [user.isAuthenticated]);

    return <Fragment>{children}</Fragment>
}

export default AuthGuard;