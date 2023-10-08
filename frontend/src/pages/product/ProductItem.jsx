import React, {useEffect, useState} from 'react';
import {useLocation} from "react-router-dom";
import {method} from "../../api/methods";
import Subscribe from "../../components/subscribe/Subscribe";

import "./productitem.css"

const ProductItem = () => {

    const location = useLocation();

    const productId = location.pathname.slice(9)

    const [product, setProduct] = useState({})

    const fetchData = async () => {

        try{
            const data = await  method.getProductById(productId)
            setProduct(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    useEffect(() => {
        fetchData()
        console.log(product)
    }, []);





    return (
        <>
            <div style={{width:"1232px" , margin:"0 auto"}}>
                <div style={{padding:"50px 0 "}}>

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
                            <img style={{width:"390px" , height:"500px"}} src={product.imageUrl} alt=""/>
                        </div>
                    </div>

                </div>
            </div>

            <Subscribe/>
        </>
    );
};

export default ProductItem;