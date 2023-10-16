import React from 'react';

const Alert = ({props}) => {
    return (
        <div style={{
            position:"absolute",
            top:"10px",
            background:"red",
            width:"100%",
            height:"1000px"
        }}>
            {props}
        </div>
    );
};

export default Alert;