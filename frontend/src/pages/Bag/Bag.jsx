import React, {useContext, useEffect, useState} from 'react';
import {MyContext} from "../../App";
import {Navigate} from "react-router-dom";
import BagElement from "./bagelement/BagElement";

import './bag.css'
import {method} from "../../api/methods";

const Bag = () => {


    const {user,setUser} = useContext(MyContext);

    const [products,setProducts] = useState([]);

    const addProduct = async () => {

        try{
            const data = await method.getCart(user.token);
            setProducts(data)
        }catch (e) {
            console.log("error" , e)
        }

    }

    useEffect(() => {
        addProduct()
    },[])


    const completeOrder = () => {

        let price = 0;

        products.map(el => {
            price = price + el.price
        })

        alert(price + "$")

    }


    const getCart  =  async () => {

        const info = await method.addToCart(user.token)

       const data = await method.getCart(user.token)

        setProducts(data)

    }


    return (

        <>
            {
                user.isAuthenticated
                    ? <div className="bag-page">
                        <div className="bag-container">

                            <div className="bag-content">
                                <div className="bag-items">
                                    <h2 className="bag-content-title">My bag</h2>


                                    {
                                        Array.isArray(products) && products.length > 0 ? (
                                                <div className="bag__elements">
                                                    {products.map(el => (
                                                        <BagElement key={el.id} props={el} />
                                                    ))}
                                                </div>
                                            ) : <div onClick={getCart}>
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