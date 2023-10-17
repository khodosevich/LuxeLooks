import React, {useEffect, useState} from 'react';

import './trending.css'

import right from '../../assets/Right.svg'
import left from '../../assets/Left.svg'
import {method} from "../../api/methods";
import TrendingNowItem from "./TrendingNowItem";

import { Audio } from 'react-loader-spinner'

const TrendingNow = () => {

    const [products,setProducts] = useState([])

    const [isFetching,setIsFetching] = useState(true);

    const [actualProduct, setActualProduct] = useState([]);

    const [index,setIndex ] = useState(0)

    const fetchData = async () => {

        try{
            const data = await method.getPopularProducts()
            setProducts(data)
        }catch (e){
            console.log("error" , e)
        }
    }



    useEffect(() => {

        setIsFetching(true)
        fetchData()
        setIsFetching(false)

    }, [actualProduct]);


    const changeTrending = (value) => {

        setIsFetching(true)

        if (value === true && index < 3) {
            setIndex(index + 1);
        } else if (value === false && index > 0) {
            setIndex(index - 1);
        }

        if( index === 0 ){
            setActualProduct(products.slice(0,3))
        }else if( index === 1) {
            setActualProduct(products.slice(3,6))
        }else if( index === 2) {
            setActualProduct(products.slice(6,9))
        }else if( index === 3) {
            setActualProduct(products.slice(9,12))
        }
        setIsFetching(false)
    }

    return (
        <div className="trending-now">
            <div className="trending__container">
                <div className="trending__content">
                    <div className="trending__title">
                        <h3>Trending Now</h3>
                        <div className="pagination">
                            <div onClick={() => changeTrending(false)} className="img__bg">
                                <img src={left} alt="left"/>
                            </div>
                          <div onClick={() => changeTrending(true)} className="img__bg">
                              <img src={right} alt="right"/>
                          </div>
                        </div>
                    </div>

                    {
                        isFetching ?
                            <div style={{display:"flex" , justifyContent:"center"} }>
                                <Audio
                                    height = "80"
                                    width = "80"
                                    radius = "9"
                                    color = 'green'
                                    ariaLabel = 'three-dots-loading'

                                />
                            </div>
                             :<>
                            <div className="trending__content__items">
                                {
                                    actualProduct.map(el => (
                                        <TrendingNowItem key={el.id} props={el}/>
                                    ))
                                }
                            </div>

                            <div className="btns__trending">
                                <button className="btn__trending" >
                                    Explore top sales
                                </button>
                            </div>
                        </>
                    }


                </div>
            </div>
        </div>
    );
};

export default TrendingNow;