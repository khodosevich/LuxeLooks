import React, {useEffect, useState} from 'react';
import {method} from "../../api/methods";
import ProductElement from "../../components/productelement/ProductElement";

const CategoriesItems = ({ isForMen, isForKids}) => {

    const [products,setProducts] = useState([])

    const fetchData = async () => {

        try{
            const data = await method.getAllProduct();
            setProducts(data)
        }catch(e) {
            console.log("error" , e)
        }

    }

    useEffect(()=>{
        fetchData()
    },[])

    return (
        <div className="categories__items__page">
            <div className="categories__items__container">
                <div className="categories__items__content">
                    <div className="categories-products__items">

                        {
                            products.map(el => (
                                el.isForMen === isForMen && el.isForKids === isForKids &&  <ProductElement key={el.id} props={el}/>
                            ))
                        }

                    </div>
                </div>
            </div>
        </div>
    );
};

export default CategoriesItems;