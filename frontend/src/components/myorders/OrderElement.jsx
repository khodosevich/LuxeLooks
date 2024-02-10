import React, {useEffect, useState} from 'react';
import {method} from "../../api/methods";
import {NavLink} from "react-router-dom";

const OrderElement = ({props}) => {


    const [product, setProduct] = useState({})

    const fetchData = async () => {

        try{
            const data = await method.getProductById(props)
            setProduct(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    useEffect(() => {
        fetchData()
    }, [])

    return (
        <div style={{display:"flex" , justifyContent:"space-between" , padding:"10px 50px"}}>
            <div style={{display:"flex" }}>
                <div className="bag-element-img">
                    <img style={{width:"80px" , height:"80px", objectFit:"cover" }} src={product.imageUrl} alt=""/>
                </div>
                <div className="bag-element-description">
                    <NavLink to={`/product/${product.id}`}>
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