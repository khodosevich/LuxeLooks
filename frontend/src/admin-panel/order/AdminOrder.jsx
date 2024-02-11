import React, {useEffect, useState} from 'react';
import {Box, Typography} from "@mui/material";
import OrderItem from "./OrderItem";
import {method} from "../../api/methods";

const AdminOrder = () => {

    const [allOrders, setAllOrders] = useState([])

    const [onUpdateStatus, setUpdateStatus] = useState(false)

    const fetchOrders = async () => {
        const token = JSON.parse(localStorage.getItem("token"))

        try{
            const data = await method.admin.getAllOrder(token)
            // console.log(data)
            setAllOrders(data.data)
        }catch (e) {
            console.log(e)
        }
    }

    useEffect(() => {
        fetchOrders()
    }, [onUpdateStatus]);


    return (
        <Box sx={{minHeight:"600px"}}>
            <Typography variant={"h4"}>Заказы: </Typography>
            <Box sx={{margin:"20px 0", display:"flex" , flexDirection:"column" , gap:"20px"}}>
                {
                    allOrders && allOrders.length > 0 &&
                    allOrders.map((el,index) => (
                        <OrderItem key={index} order={el} onUpdateStatus={setUpdateStatus}/>
                    ))
                }
            </Box>
        </Box>
    );
};

export default AdminOrder;