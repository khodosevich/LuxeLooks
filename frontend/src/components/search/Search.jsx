import React, { useEffect, useState} from 'react';
import {Box, List, ListItem, ListItemText} from "@mui/material";
import { useNavigate } from "react-router-dom";
import {method} from "../../api/methods";
import "../header/header.css"

const Search = () => {

    const [searchState,setSearchState] = useState("");
    const [searchError, setSearchError] = useState("");

    const [filterNames, setFilterNames] = useState([])

    const handlerSearchInput = (e) => {
        const value = e.target.value;
        setSearchState(value);

        if (value.length < 1) {
            setSearchError("Please enter at least 3 characters.");
        } else {
            setSearchError("");
        }

        if(value.length > 0) {
            const filtered = productsName.filter(product => product.toLowerCase().includes(value.toLowerCase()))
            setFilterNames(filtered)
        }

        if(value.length === 0) {
            setFilterNames(null)
        }
    }

    const handleKeyDown = (e) => {
        if (e.key === 'Enter') {
            e.preventDefault();
            search();
        }
    }

    const [productsName,setProductsName] = useState([])

    const fetchProduct = async () => {
        try {
            const data = await method.getAllProductsName()
            setProductsName(data.data)
        }catch (e) {
            console.log(e)
        }
    }

    let navigate = useNavigate();
    useEffect(() => {
        fetchProduct()
    }, []);

    useEffect(() => {

    },[])

    const search = async () => {
        if (searchState.length >= 1) {
            navigate(`search/${searchState}`);
            setSearchState("");
        }
    }

    const searchName = async ( name ) => {
        if (name.length >= 1) {
            const data = await method.getProductByName(name)
            console.log(data)
            navigate(`product/${data.id}`);
            setSearchState("");
        }
    }

    const handleBlur = () => {
        setSearchError("");
        setFilterNames(null)
    }

    return (
        <Box sx={{display:"flex" , flexDirection:"column"}}>
            <Box className="search-input">
                <input
                    value={searchState}
                    onKeyDown={handleKeyDown}
                    onChange={handlerSearchInput}
                    onBlur={handleBlur}
                    className={`input_header ${searchError ? "error" : ""}`}
                    type="text"
                    placeholder="Search for products..."
                />
                <i onClick={search} className="fa" aria-hidden="true"></i>
                {searchError && <div className="error-message">{searchError}</div>}
            </Box>

            {
                filterNames && filterNames.length > 0 &&
                <div style={{position:"absolute", top:"65px"}}>
                    <List style={{display:"flex", flexDirection:"column" , gap:"5px" }}>
                        {
                            filterNames.map((el,index) => (
                                <ListItem
                                    onClick={() => searchName(el)}
                                    sx={{
                                    background:"#a9a9a9",
                                    width:"410px",
                                    borderRadius:"10px",
                                    cursor:"pointer",
                                    height:"40px",
                                    color:"black",
                                }}
                                    key={index}
                                >
                                    <ListItemText primary={el}/>
                                </ListItem>
                            ))
                        }
                    </List>
                </div>
            }
        </Box>
    );
};

export default Search;