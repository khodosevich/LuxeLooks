import React, {useEffect, useState} from 'react';
import {Box, Typography} from "@mui/material";
import {method} from "../../api/methods";
import ProductCard from "./ProductCard";

const AdminChangeProduct = () => {

    const [products, setProducts] = useState([])

    const [updateState,setUpdateState] = useState(false)

    const fetchProduct = async () => {
        const token = JSON.parse(localStorage.getItem("token"))

        try {
            const data = await method.admin.getAllProducts(token)

            console.log(data)

            setProducts(data.data)

        }catch (e) {
            console.log(e)
        }

    }

    useEffect(() => {
        fetchProduct()
    }, [updateState]);

    return (
        <Box>
            <Typography variant={"h4"}>Update product: </Typography>
            <Box sx={{display:"flex", flexWrap:"wrap" , gap:"20px", marginTop:"20px"}}>
                {
                    products && products.length > 0 &&
                    products.map((el) => (
                        <ProductCard key={el.id} product={el} setUpdateState={setUpdateState}/>
                    ))
                }
            </Box>
        </Box>
    );
};

export default AdminChangeProduct;