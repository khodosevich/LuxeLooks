import React, {useContext, useEffect, useState} from 'react';
import {MyContext} from "../../App";
import {Navigate} from "react-router-dom";
import BagElement from "./bagelement/BagElement";

import './bag.css'
import {method} from "../../api/methods";
import { Button, TextField} from "@mui/material";
import jwt_decode from "jwt-decode";
import OwnAlert from "../../components/alert/OwnAlert";

const Bag = () => {


    const {user,setUser} = useContext(MyContext);

    const [products,setProducts] = useState([]);

    const [order,setOrder] = useState({
        Name: "",
        Email: "",
        Address: "",
        ProductsIds: [""],
        Price: 0,
        UserId: ""
    })

    const [alertStatus, setAlertStatus] = useState(false)

    const [alertConfig, setAlertConfig] = useState({})

    const getCart = async () => {

        try{
            const data = await method.getCart(user.token);
            setProducts(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    const removeProductFromCart = async (productId) => {

        try{
            await method.removeFromCart(productId,user.token).then(r => {

                setAlertConfig( ({
                    type: "success",
                    statusText: "Remove item form cart!"
                }));
            })

            setAlertStatus(true)
            setTimeout(() => setAlertStatus(false), 4000);


        }catch (error) {
            setAlertConfig( ({
                type: "error",
                statusText: error.response.statusText
            }));

            setAlertStatus(true)
            setTimeout(() => setAlertStatus(false), 4000);

        }

        const data = await method.getCart(user.token)

        setProducts(data);
    }


    const completeOrder = (data) => {

        setModalIsOpen(true)

        method.createOrder(data , user.token)
    }


    useEffect(() => {
        getCart()
    },[])



    const [modalIsOpen,setModalIsOpen] = useState(false)

    const getId = () => {
        const token = user.token;
        const decoded = jwt_decode(token);

        const idUser = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

        return idUser;
    }

    const [isOrderPlaced, setIsOrderPlaced] = useState(false);

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

                method.removeAllCart(user.token)
                setProducts([])
                setModalIsOpen(false);
                setIsOrderPlaced(false);
            }
        }
    }, [isOrderPlaced, order]);



    return (

        <>
            {
                user.isAuthenticated
                    ? <div className="bag-page">

                        {
                            modalIsOpen && <div style={{
                                position:"absolute",
                                top:"0",
                                height:"100vh",
                                width:"100vw",
                                zIndex:"1000",

                                background:"#1E212C"
                            }}>
                                <div style={{
                                    display:"flex",
                                    alignItems:"center",
                                    justifyContent:"center",
                                    height:"100%"
                                }}>
                                    <div style={{
                                        background:"white",
                                        padding:"100px 200px",
                                        display:"flex",
                                        flexDirection:"column",

                                    }}>


                                        <h3>
                                            Form for complete order:
                                        </h3>


                                        <div style={{
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
                                        </div>

                                        <Button
                                            style={{
                                                margin:"20px 0"
                                            }}
                                            onClick={completeOrderRequest}
                                                variant="contained">
                                            Place an order
                                        </Button>

                                        <div>
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

                                                onClick={ () => setModalIsOpen(false) }>
                                                cancel
                                            </button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        }
                        <div className="bag-container">

                            <div className="bag-content">
                                <div className="bag-items">
                                    <h2 className="bag-content-title">My bag</h2>


                                    {
                                        alertStatus && <OwnAlert props={alertConfig}/>
                                    }


                                    {
                                        products.length > 0 ? (
                                                <div className="bag__elements">
                                                    {products.map((el,index) => (
                                                        <BagElement key={index} props={el} removeProductFromCart={removeProductFromCart} />
                                                    ))}



                                                    <div>
                                                        <button
                                                            style={{
                                                                color: "#FFF",
                                                                textAlign: "center",
                                                                fontFamily: "Lato",
                                                                fontSize: "14px",
                                                                fontStyle: "normal",
                                                                fontWeight: "700",
                                                                lineHeight: "44px",
                                                                letterSpacing: "0.5px",
                                                                borderRadius: "4px",
                                                                background: "#17696A",
                                                                minWidth:"100%",
                                                                border:"0",
                                                                marginTop:"20px",
                                                                cursor:"pointer"
                                                            }}

                                                            onClick={ () => setModalIsOpen(true)}>
                                                            complete order
                                                        </button>
                                                    </div>

                                                </div>
                                            ) : <div>
                                               Bag is empty
                                            </div>
                                    }

                                </div>
                                <div className="bag-info__user">
                                    <h3 className="bag-info__user__name">
                                        {user.username}
                                    </h3>
                                    <p className="bag-info__user__email">
                                        {user.email}
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    :<Navigate to="/signin"/>
            }
        </>


    );
};

export default Bag;