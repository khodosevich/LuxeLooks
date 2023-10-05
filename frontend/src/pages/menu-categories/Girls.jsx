import React, {useContext, useEffect, useState} from 'react';
import {MyContext} from "../../App";
import {method} from "../../api/methods";
import ProductElement from "../../components/productelement/ProductElement";

const Girls = () => {

    const [product,setProduct] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await method.getAllProduct();
                setProduct(data);
            } catch (error) {
                console.error("Произошла ошибка:", error);
            }
        }
        fetchData();
    }, []);


    return (
        <div className="categories__items__page">
            <div className="categories__items__container">
                <div className="categories__items__content">
                    <div className="categories-products__items">

                        {
                            product.map(el => (
                                !(el.isForMen) && el.isForKids && <ProductElement key={el.id} props={el}/>
                            ))
                        }

                    </div>
                </div>
            </div>
        </div>
    );
};

export default Girls;