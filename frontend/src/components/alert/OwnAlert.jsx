import React, {useEffect, useState} from 'react';
import {Alert, AlertTitle} from "@mui/material";

const OwnAlert = ({props}) => {


    const [alertType, setAlertType] = useState({})

    useEffect(() => {
        setAlertType(props)
    }, []);

    return (
        <Alert

            style={{
                position:"absolute",
                top:"5%",
                width:"1200px",
                zIndex:"2000",
                transition:"1.5s"
            }}

            severity={alertType.type}>
            <AlertTitle>{alertType.type}</AlertTitle>
            <strong>{alertType.statusText}</strong>
        </Alert>
    );
};

export default OwnAlert;