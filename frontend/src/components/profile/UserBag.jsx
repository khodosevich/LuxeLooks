import React, {useEffect, useState} from 'react';
import {method} from "../../api/methods";
import {Box} from "@mui/material";
import BagElement from "../../pages/Bag/bagelement/BagElement";

const UserBag = () => {

    const [product, setProduct] = useState([])

    const getCart = async () => {

        const token = JSON.parse(localStorage.getItem("token"))
        try{
            const data = await method.getCart(token);
            setProduct(data)
        }catch (e) {
            console.log("error" , e)
        }
    }

    const removeProductFromCart = async (productId) => {

        const token = JSON.parse(localStorage.getItem("token"))
        try{
            await method.removeFromCart(productId,token).then(r => {

            })

        }catch (error) {

        }

        const data = await method.getCart(token)

        setProduct(data);
    }

    useEffect(() => {
        getCart()
    }, []);


    return (
        <Box sx={{margin:"0 0 100px 0", display:"flex" , flexDirection:"column" , gap:"20px"}}>
            {product.map((el,index) => (
                <BagElement key={index} props={el} removeProductFromCart={removeProductFromCart} />
            ))}
        </Box>
    );
};

export default UserBag;