import React, {useEffect, useState} from 'react';
import {method} from "../../api/methods";
import {NavLink} from "react-router-dom";
import {logDOM} from "@testing-library/react";

const OrderElement = ({props}) => {

    console.log("props" , props)

    const [product, setProduct] = useState({})

    const fetchData = async () => {

        try{
            console.log("before method" , props)
            const data = await method.getProductById(props)
            setProduct(data)
            console.log('after method',product)
        }catch (e) {
            console.log("error" , e)
        }
    }

    useEffect(() => {
        fetchData()
        console.log(product)
    }, [])

    return (
        <div style={{display:"flex" , justifyContent:"space-between" , padding:"10px 50px"}}>
            <div style={{display:"flex" }}>
                <div className="bag-element-img">
                    <img style={{width:"80px" , height:"80px", objectFit:"cover" }} src={product.imageUrl} alt=""/>
                </div>
                <div className="bag-element-description">

                    <NavLink to={`/product/${props.id}`}>
                        <h3 className="bag-element-description__title">
                            {product.name}
                        </h3>
                    </NavLink>
                    <p className="bag-element-description__color">
                        Type: {product.type}
                    </p>
                </div>
            </div>


            <h3 className="bag-element-price">
                {product.price}$
            </h3>


        </div>
    );
};

export default OrderElement;