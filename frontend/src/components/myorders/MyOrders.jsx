import React, {useContext, useEffect, useState} from 'react';
import {MyContext} from "../../App";
import {method} from "../../api/methods";
import jwt_decode from "jwt-decode";
import OrderItem from "./OrderItem";
import {Typography} from "@mui/material";

const MyOrders = () => {

    const {user,setUser} = useContext(MyContext);

    const [ordersHistory, setOrdersHistory] = useState([])

    const getOrdersById = async () =>{


        const token = user.token;
        const decoded = jwt_decode(token);

        const userId = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        const data = await method.getOrderById(userId, user.token)

        setOrdersHistory(data)
    }

    useEffect(() => {
        getOrdersById()
    }, []);

    return (
        <div style={{width:"100%"}}>
            <h3 style={{
                color: "#1E212C",
                fontFamily: "Lato",
                fontSize: "32px",
                fontStyle: "normal",
                fontWeight: "900",
                lineHeight: "130%"
            }}>
                My orders
            </h3>
            <div>
                {
                    ordersHistory && ordersHistory.length > 0 ? ordersHistory.map((el, index) => (<OrderItem key={index} props={el} />))
                        : <Typography sx={{marginTop:"20px"}} variant={"h6"}>У вас пока нет заказов! </Typography>
                }

            </div>
        </div>
    );
};

export default MyOrders;