import React, {useContext, useEffect, useState} from 'react';
import {MyContext} from "../../App";
import {Navigate, useNavigate} from "react-router-dom";
import BagElement from "./bagelement/BagElement";
import './bag.css'
import {method} from "../../api/methods";
import OwnAlert from "../../components/alert/OwnAlert";

const Bag = () => {

    const {user,setUser} = useContext(MyContext);
    const [products,setProducts] = useState([]);
    const [alertStatus, setAlertStatus] = useState(false)
    const [alertConfig, setAlertConfig] = useState({})
    const navigate= useNavigate()

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

    useEffect(() => {
        getCart()
    },[])


    const navigateToFrom = () => {
        navigate("/bag/order")
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
                                                            onClick={navigateToFrom}>
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