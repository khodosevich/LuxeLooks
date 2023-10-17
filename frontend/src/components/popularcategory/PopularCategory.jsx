import React, {useEffect, useState} from 'react';

import './popularcategory.css'
import {method} from "../../api/methods";
import PopularCategoryItem from "./PopularCategoryItem";



const PopularCategory = () => {

    const [product,setProduct] = useState([])

    const setDataCategory = async () => {
        try{
            const data = await method.getAllProduct();

            const uniqueProducts = Array.from(new Set(data));

            const limitedProducts = uniqueProducts.slice(0, 6);
            setProduct(limitedProducts);
        }catch(e){
            console.log("Error: " , e)
        }
    }

    useEffect(() => {

        setDataCategory();
    }, []);


    return (
        <div className="popular-category">
            <div className="popular-category__container">
                <div className="popular-category__content">
                    <h3 className="popular-category__title">Popular categories</h3>
                    <div className="popular-category__items">
                        {
                            product.map(el => (
                                <PopularCategoryItem key={el.id} props={el}/>
                            ))
                        }
                    </div>
                </div>
            </div>
        </div>
    );
};

export default PopularCategory;