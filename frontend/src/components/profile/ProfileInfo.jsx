import React, {useContext, useEffect, useState} from 'react';
import {Box, TextField, Typography} from "@mui/material";
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';
import jwt_decode from "jwt-decode";
import UserFieldForm from "./UserFieldForm";

const ProfileInfo = () => {

    const [user, setUser] = useState({
        name:"",
        email:"",
        id:""
    })

    const fetchUser = () => {
        const user = JSON.parse(localStorage.getItem("token"))
        const decoded = jwt_decode(user);

        setUser({
            name:decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
            email: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
            id: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"]
        })
    }

    useEffect(() => {
        fetchUser()
    }, []);

    return (
        <Box sx={{ width:"810px" , height:"500px"}}>
            <Box sx={{display:"flex", alignItems:"center" , justifyContent:"space-between"}}>
                <Typography sx={{fontWeight:700}} variant={"h4"}>My profile</Typography>
                <Box sx={{display:"flex", alignItems:"center" , justifyContent:"center", gap:"3px", cursor:"pointer"}}>
                    <DeleteOutlineIcon sx={{color:"#FF4242"}}/>
                    <Typography sx={{color:"#FF4242"}} variant={"body1"}>
                        Delete account
                    </Typography>
                </Box>
            </Box>
            <Box style={{marginTop:"30px"}}>
                <Box  sx={{display:"flex", alignItems:"center", gap:"35px"}} >
                    <UserFieldForm type={"Name"} value={user.name}/>
                    <UserFieldForm type={"Email"} value={user.email}/>
                </Box>
                <Box  sx={{display:"flex", alignItems:"center" , gap:"40px", marginTop:"20px"}} >
                    <UserFieldForm type={"Id"} value={user.id}/>
                </Box>
            </Box>
        </Box>
    );
};

export default ProfileInfo;