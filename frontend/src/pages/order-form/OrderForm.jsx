import React, {useEffect, useState} from 'react';
import {Box, Button, TextField} from "@mui/material";
import jwt_decode from "jwt-decode";
import {method} from "../../api/methods";
import {useNavigate} from "react-router-dom";
import OrderItem from "./OrderItem";

const OrderForm = () => {

    const token = JSON.parse(localStorage.getItem("token"))
    const [isOrderPlaced, setIsOrderPlaced] = useState(false);
    const [order,setOrder] = useState({
        Name: "",
        Email: "",
        Address: "",
        ProductsIds: [""],
        Price: 0,
        UserId: ""
    })
    const [products,setProducts] = useState([]);
    const navigate= useNavigate()

    const getId = () => {
        const token = JSON.parse(localStorage.getItem("token"));
        const decoded = jwt_decode(token);
        return decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    }

    const completeOrderRequest = () => {
        const id = getId();

        let totalPrice = products.reduce((total, product) => total + product.price, 0);
        totalPrice = totalPrice.toFixed(2);

        const ids = products.map(product => product.id);

        setOrder(prevOrder => ({
            ...prevOrder,
            ProductsIds: ids,
            Price: totalPrice,
            UserId: id
        }));

        setIsOrderPlaced(true);
    }

    const completeOrder = (data) => {
        method.createOrder(data , token)
    }

    const getCart = async () => {

        try{
            const data = await method.getCart(token);
            setProducts(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    useEffect(() => {
        getCart()
        window.scrollTo(0, 0);
    },[])

    useEffect(() => {
        if (isOrderPlaced) {
            if (order.Price > 0 && order.UserId !== "") {
                completeOrder(order);
                setOrder({
                    Name: "",
                    Email: "",
                    Address: "",
                    ProductsIds: [""],
                    Price: 0,
                    UserId: ""
                });

                method.removeAllCart(token)
                setProducts([])
                setIsOrderPlaced(false);
                navigate('/account/myorders')
            }
        }
    }, [isOrderPlaced, order]);

    return (<Box style={{
            background:"#b0b0b0",
            padding:"30px 0 50px 0",
        }}>
            <Box style={{
                display:"flex",
                alignItems:"center",
                justifyContent:"center",
                flexDirection:"column",
            }}>
                <Box style={{
                    background:"white",
                    padding:"50px 100px",
                    display:"flex",
                    flexDirection:"column",
                    marginBottom:"100px"
                }}>
                    <h3>
                        Form for complete order:
                    </h3>
                    <Box style={{
                        display:"flex",
                        flexDirection:"column",
                        gap:"20px",
                        marginTop:"30px"
                    }}>
                        <TextField
                            value={order.Name}
                            id="outlined-basic"
                            label="Name"
                            variant="outlined"
                            onChange={(e) => setOrder({ ...order, Name: e.target.value })}
                        />
                        <TextField
                            value={order.Address}
                            id="outlined-basic"
                            label="Adress"
                            variant="outlined"
                            onChange={(e) => setOrder({ ...order, Address: e.target.value })}
                        />
                        <TextField
                            value={order.Email}
                            id="outlined-basic"
                            label="Email"
                            variant="outlined"
                            onChange={(e) => setOrder({ ...order, Email: e.target.value })}
                        />
                    </Box>
                    <Button
                        style={{
                            margin:"20px 0"
                        }}
                        onClick={completeOrderRequest}
                        variant="contained">
                        Place an order
                    </Button>
                    <Box>
                        <button
                            style={{
                                color: "#ffffff",
                                textAlign: "center",
                                fontFamily: "Lato",
                                fontSize: "14px",
                                fontStyle: "normal",
                                fontWeight: "700",
                                lineHeight: "44px",
                                borderRadius: "4px",
                                background: "#ef4e4e",
                                minWidth:"100%",
                                border:"0",
                                cursor:"pointer"
                            }}
                            onClick={() => navigate("/bag")}
                        >
                            cancel
                        </button>
                    </Box>
                    <Box sx={{marginTop:"20px", marginBottom:"50px"}}>
                        <Box sx={{display:"flex", flexDirection:"column", gap:"10px"}}>
                            {
                                products && products.map((el,index) => (
                                     <OrderItem key={index} props={el} />
                                ))
                            }
                        </Box>
                    </Box>
                </Box>
            </Box>
        </Box>
    );
};

export default OrderForm;