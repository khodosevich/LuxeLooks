import React from 'react';
import {Box} from "@mui/material";

const UserFieldForm = ({type,value}) => {
    return (
        <Box>
            <label style={{display:"block", marginBottom:"10px"}}>{type}:</label>
            <input style={{outline:"0" , border:"1px solid grey" , borderRadius:"5px",color:"black", padding:"10px", fontSize:"15px",width:"365px"}} value={value} />
        </Box>
    );
};

export default UserFieldForm;