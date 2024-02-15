import React, {useEffect, useState} from 'react';
import {Box, MenuItem, Select, Typography} from "@mui/material";
import ProductElement from "../../components/productelement/ProductElement";
import {method} from "../../api/methods";
import {useLocation} from "react-router-dom";

const FilteredProducts = () => {

    const location = useLocation()
    const title = location.pathname.substring(8)

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
                }
            });
            return sortedProducts;
        });

    };

    const fetchData = async () => {
        try{
            const data = await method.getAllProductsName();
            console.log(data.data)
            const filtered = data.data.filter(product => product.toLowerCase().includes(title.toLowerCase()))

            for (let i = 0; i < filtered.length; i++) {
                const prod = await method.getProductByName(filtered[i])
                setProducts(prev => [...prev, prod] )
            }
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
                            Поиск: {title}
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
                                <ProductElement key={el.id} props={el}/>
                            ))
                        }
                    </Box>
                </Box>
            </Box>
        </Box>
    );
};

export default FilteredProducts;