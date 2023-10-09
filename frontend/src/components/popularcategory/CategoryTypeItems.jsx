import React, {useEffect, useState} from 'react';
import {useLocation} from "react-router-dom";
import {method} from "../../api/methods";
import ProductElement from "../productelement/ProductElement";

const CategoryTypeItems = ({category}) => {

    const location =  useLocation()

    const type = location.pathname.slice(10)

    const [products, setProducts] = useState([])

    const fetchData = async () => {
        try{
            const data = await method.getAllProduct()
            setProducts(data)
        }catch (e){
            console.log("error", e)
        }
    }

    useEffect(() => {
        fetchData()
        console.log("popular " , products)
    }, []);

    return (
        <div style={{width:"1232px" , margin:"0 auto"}}>
            <div style={{margin:"50px 0" }}>
                <h2 style={{
                    color:  "#1E212C",
                    fontFamily: "Lato",
                    fontSize: "30px",
                    fontWeight:"900",
                    lineHeight: "130%",
                    margin:"20px 0"
                }}>Products in category: {category} {type}  </h2>

                <div  style={{ display:"flex" , gap:"50px" , alignItems:"center" , justifyContent:"center" , flexWrap:"wrap"} }>
                    {
                        products.map(el => (
                            el.type === type &&  <ProductElement key={el.id} props={el}/>
                        ))
                    }
                </div>
            </div>

        </div>
    );
};

export default CategoryTypeItems;