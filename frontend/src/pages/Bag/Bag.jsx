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
            const data = await method.getAllProduct();
            setProducts(data)
        }catch (e) {
            console.log("error" , e)
        }

    }

    useEffect(() => {
        addProduct()
    },[])


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
                                        products.length > 0
                                            ? <>
                                                <div className="bag__elements">
                                                    {
                                                        products.map(el => (
                                                            <BagElement key={el.id} props={el} />
                                                        ))
                                                    }
                                                </div>
                                                <div className="confirm-order">
                                                    <button className="btn__confirm-order">
                                                        Complete order
                                                    </button>
                                                </div>
                                            </>

                                            : <>
                                               Bag is empty
                                            </>
                                    }

                                    <button onClick={addProduct}>click</button>

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