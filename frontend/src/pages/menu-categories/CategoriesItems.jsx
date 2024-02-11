import React, {useEffect, useState} from 'react';
import {method} from "../../api/methods";
import ProductElement from "../../components/productelement/ProductElement";
import {Box, MenuItem, Select, Typography} from "@mui/material";

const CategoriesItems = ({ isForMen, isForKids}) => {

    const [products,setProducts] = useState([])
    const [sortBy, setSortBy] = useState('sort');

    const handleSortChange = (event) => {

        const sortByValue = event.target.value;
        setSortBy(sortByValue);

        setProducts(prevProducts => {
            const sortedProducts = [...prevProducts];
            sortedProducts.sort((a, b) => {
                if (sortByValue === 'price') {
                    return a.price - b.price;
                } else if( sortByValue === 'name' ) {
                    return a.name.localeCompare(b.name);
                } else {
                    fetchData()
                }
            });
            return sortedProducts;
        });

    };

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
        <Box className="categories__items__page">
            <Box className="categories__items__container">
                <Box className="categories__items__content">
                    <Box sx={{ display: 'flex', alignItems: 'center', justifyContent:"space-between", marginBottom: '20px' }}>
                        <Typography sx={{ fontWeight: '700', marginRight: '10px' }} variant={'h5'}>
                            Товары для {isForMen && isForKids ? 'мальчиков' : isForMen ? 'мужчин' : isForKids ? 'девочек' : 'женщин'}:
                        </Typography>
                        <Select
                            value={sortBy}
                            onChange={handleSortChange}
                            sx={{ minWidth: '220px' }}
                            variant="outlined"
                        >
                            <MenuItem value="sort">Сортировка</MenuItem>
                            <MenuItem value="price">По цене</MenuItem>
                            <MenuItem value="name">По названию</MenuItem>
                        </Select>
                    </Box>
                    <Box className="categories-products__items">
                        {
                            products.map(el => (
                                el.isForMen === isForMen && el.isForKids === isForKids &&  <ProductElement key={el.id} props={el}/>
                            ))
                        }
                    </Box>
                </Box>
            </Box>
        </Box>
    );
};

export default CategoriesItems;