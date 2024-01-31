import React, {useContext, useEffect, useState} from 'react';
import {useLocation} from "react-router-dom";
import {api, method} from "../../api/methods";
import Subscribe from "../../components/subscribe/Subscribe";

import "./productitem.css"
import ProductNotExist from "../../components/productelement/ProductNotExist";
import {MyContext} from "../../App";
import OwnAlert from "../../components/alert/OwnAlert";
import Reviews from "../../components/reviews/Reviews";

const ProductItem = () => {

    const {user,setUser} = useContext(MyContext)

    console.log("user: ", user)

    const location = useLocation();

    const productId = location.pathname.slice(9)

    const [product, setProduct] = useState({})

    const [alertStatus, setAlertStatus] = useState(false)

    const [alertConfig, setAlertConfig] = useState({})

    const fetchData = async () => {

        try{
            const data = await  method.getProductById(productId)
            setProduct(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    useEffect(() => {
        window.scrollTo(0, 0);
        fetchData()
    }, [productId]);


    const addToCart = async () => {
        try {
            const response = await method.addToCart(product.id, user.token).then(r => {
                setAlertConfig({
                    type: "success",
                    statusText: "Add element to cart"
                })
            })

            setAlertStatus(true)
            setTimeout(() => setAlertStatus(false), 4000);

        } catch (error) {

            console.log(error)

            setAlertConfig({
                type: "error",
                statusText: error.response.statusText
            })

            setAlertStatus(true)
            setTimeout(() => setAlertStatus(false), 4000);
        }

    }


    return (
        <>
            <div style={{width:"1232px" , margin:"0 auto" , position:"relative"}}>
                <div style={{padding:"50px 0 "}}>

                    {
                        product.name
                            ? <>

                          <div style={{display:"flex"  , justifyContent:"space-between"}}>
                                        <h3 style={{
                                            color:"#1E212C",
                                            fontFamily: "Lato",
                                            fontSize: "46px",
                                            fontStyle: "normal",
                                            fontWeight: "900",
                                            lineHeight: "130%",
                                            marginBottom:"32px"
                                        }}>
                                            {product.name}
                                        </h3>
                                        <p style={{
                                            color: "#787A80",
                                            fontFamily: "Lato",
                                            fontsize: "16px",
                                            fontStyle: "normal",
                                            fontWeight: "400",
                                            lineHeight: "160%"
                                        }}>
                                    <span style={{
                                        fontWeight: "700"
                                    }}>Art. No.</span> {product.id}
                                        </p>
                                    </div>

                          {
                            alertStatus && <OwnAlert props={alertConfig} />
                          }


                                    <div style={{
                                        width: "1230px",
                                        height: "1px",
                                        background: "#E5E8ED",
                                        marginBottom:"32px"
                                    }}>

                                    </div>
                                <div style={{display:"flex" , justifyContent:"space-between" }}>
                            <div>
                                <h4 style={{
                                    color:"#1E212C",
                                    fontFamily: "Lato",
                                    fontSize: "20px",
                                    fontStyle: "normal",
                                    fontWeight: "700",
                                    lineHeight:"150%"
                                }}>
                                    Description
                                </h4>
                                <p style={{
                                    color: "#424551",
                                    fontFamily: "Lato",
                                    fontSize: "16px",
                                    fontStyle: "normal",
                                    fontWeight: "400",
                                    lineHeight: "160%",
                                    maxWidth:"735px"
                                }}>
                                    {product.description}
                                </p>

                                <div style={{
                                    width: "735px",
                                    height: "1px",
                                    background: "#E5E8ED",
                                    margin:"32px 0"
                                }}>
                                </div>

                                <div>
                                    <h4 style={{
                                        color: "#1E212C",
                                        fontFamily: "Lato",
                                        fontSize: "20px",
                                        fontStyle: "normal",
                                        fontWeight: "700",
                                        lineHeight: "150%"
                                    }}>
                                        Fabric
                                    </h4>

                                    <ul className="menu__fabric"  style={{
                                        color:  "#424551",
                                        fontFamily: "Lato",
                                        fontSize: "16px",
                                        fontStyle: "normal",
                                        fontWeight: "400",
                                        lineHeight: "160%",
                                    }}>
                                        <li className="fabric__item">
                                            Upper: 50% real leather, 50% textile
                                        </li>
                                        <li className="fabric__item">
                                            Lining: 100% textile
                                        </li>
                                        <li className="fabric__item">
                                            Sole: 100% other materials
                                        </li>
                                    </ul>

                                </div>


                                <div style={{
                                    width: "735px",
                                    height: "1px",
                                    background: "#E5E8ED",
                                    margin:"32px 0"
                                }}>
                                </div>

                                <div>
                                    <h4 style={{
                                        color: "#1E212C",
                                        fontFamily: "Lato",
                                        fontSize: "20px",
                                        fontStyle: "normal",
                                        fontWeight: "700",
                                        lineHeight: "150%"
                                    }}>
                                        Care
                                    </h4>

                                    <ul style={{
                                        color:  "#424551",
                                        fontFamily: "Lato",
                                        fontSize: "16px",
                                        fontStyle: "normal",
                                        fontWeight: "400",
                                        lineHeight: "160%"
                                    }}>
                                        <li className="item__care item__care__first">
                                            Hand wash only (30°)
                                        </li>
                                        <li  className="item__care item__care__second">
                                            No ironing
                                        </li>
                                        <li  className="item__care item__care__third">
                                            Do not use any bleach
                                        </li>
                                        <li  className="item__care item__care__four">
                                            Do not tumble dry
                                        </li>
                                    </ul>

                                </div>
                            </div>
                            <div>

                                <div>
                                    <img style={{width:"390px" , height:"500px"}} src={product.imageUrl} alt=""/>
                                </div>
                               <div>
                                   <button onClick={addToCart} style={{
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
                                   }}>
                                       add to cart
                                   </button>
                               </div>

                            </div>
                        </div>

                            <Reviews productId={productId} userToken={user.token}/>
                            </> : <>
                              <ProductNotExist/>
                          </>
                    }

                </div>
            </div>

            <Subscribe/>
        </>
    );
};

export default ProductItem;