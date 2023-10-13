import React, {useContext, useEffect, useState} from 'react';
import {MyContext} from "../../App";
import {Navigate} from "react-router-dom";
import BagElement from "./bagelement/BagElement";

import './bag.css'
import {method} from "../../api/methods";
import {AlertTitle, Button, TextField} from "@mui/material";
import jwt_decode from "jwt-decode";
import Alert from "../../components/alert/Alert";

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

    const getCart = async () => {

        try{
            const data = await method.getCart(user.token);
            setProducts(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    const removeProductFromCart = async (productId) => {

        await method.removeFromCart(productId,user.token)

        const data = await method.getCart(user.token)

        setProducts(data);
    }


    const completeOrder = (data) => {

        console.log(data)

        setModalIsOpen(true)

        method.createOrder(data , user.token)
    }


    useEffect(() => {
        getCart()
    },[])


    const [isAlert, setIsAlert] = useState(false)
    
    const [modalIsOpen,setModalIsOpen] = useState(false)

    const getId = () => {
        const token = user.token;
        const decoded = jwt_decode(token);

        const idUser = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

        return idUser;
    }

    const completeOrderRequest =  () => {

        const id = getId()

        const totalPrice = products.reduce((total, product) => total + product.price, 0);

        const ids = products.map(product => product.id);

        setOrder({
            ...order,
            ProductsIds: ids,
            Price: totalPrice,
            UserId: id
        })


        if(order.Price > 0 && order.UserId !== "") {
            
            completeOrder(order)
            setOrder({
                Name: "",
                Email: "",
                Address: "",
                ProductsIds: [""],
                Price: 0,
                UserId: ""
            })


            setModalIsOpen(false);
        }
    }



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
                                        gap:"50px"
                                    }}>

                                        <div>
                                            <button onClick={ () => setModalIsOpen(false) }>
                                                close
                                            </button>
                                        </div>

                                        {
                                            isAlert && <Alert props={"hello"}/>
                                        }

                                        Form for complete order

                                        <div style={{
                                            display:"flex",
                                            flexDirection:"column",
                                            gap:"20px"
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

                                        <Button onClick={completeOrderRequest}
                                                variant="contained">
                                            Place an order
                                        </Button>

                                    </div>
                                </div>
                            </div>
                        }
                        <div className="bag-container">

                            <div className="bag-content">
                                <div className="bag-items">
                                    <h2 className="bag-content-title">My bag</h2>

                                    {
                                        products.length > 0 ? (
                                                <div className="bag__elements">
                                                    {products.map((el,index) => (
                                                        <BagElement key={index} props={el} removeProductFromCart={removeProductFromCart} />
                                                    ))}

                                                    <div>
                                                        <button onClick={ () => setModalIsOpen(true)}>
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