import React, { useState } from 'react';
import {
    TextField,
    Button,
    Checkbox,
    FormGroup,
    FormControl,
    FormControlLabel,
    Select,
    MenuItem,
    Box, Typography
} from '@mui/material';
import {method} from "../../api/methods";

const AdminNewProduct = () => {
    const [productData, setProductData] = useState({
        price: 0,
        name: '',
        description: '',
        type: '',
        imageUrl: '',
        isForMen: false,
        isForKids: false
    });

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setProductData(prevData => ({
            ...prevData,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleSubmit = async () => {

        const token = JSON.parse(localStorage.getItem("token"))

        try {
            const data = await method.admin.createProduct(token,productData)
            console.log(data)
            setProductData({
                price: 0,
                name: '',
                description: '',
                type: '',
                imageUrl: '',
                isForMen: false,
                isForKids: false
            })
        }catch (e) {
            console.log(e)
        }
    };

    return (
        <Box sx={{display:"flex", flexDirection:"column", gap:"20px", justifyContent:"center"}}>
            <Typography variant={"h4"}>Create new product:</Typography>
           <Box sx={{display:"flex", flexDirection:"row", gap:"20px"}}>
               <TextField
                   label="Price"
                   name="price"
                   type="number"
                   value={productData.price}
                   onChange={handleChange}
               />
               <TextField
                   label="Name"
                   name="name"
                   value={productData.name}
                   onChange={handleChange}
               />
           </Box>
            <Box sx={{display:"flex", flexDirection:"row", gap:"20px"}}>
                <TextField
                    label="Description"
                    name="description"
                    value={productData.description}
                    onChange={handleChange}
                />
                <FormControl sx={{width:"195px"}} >
                    <Select
                        value={productData.type}
                        onChange={handleChange}
                        displayEmpty
                        inputProps={{ 'aria-label': 'Without label' }}
                        name="type"
                    >
                        <MenuItem value="" disabled>
                            Type
                        </MenuItem>
                        <MenuItem value="Shoes">Shoes</MenuItem>
                        <MenuItem value="Pants">Pants</MenuItem>
                        <MenuItem value="Shirt">Shirt</MenuItem>
                        <MenuItem value="Trouser">Trouser</MenuItem>
                        <MenuItem value="Jacket">Jacket</MenuItem>
                        <MenuItem value="Shirt">Shirt</MenuItem>
                    </Select>
                </FormControl>
            </Box>
              <Box  sx={{display:"flex", flexDirection:"row", gap:"20px"}}>
                  <TextField
                      label="Image URL"
                      name="imageUrl"
                      value={productData.imageUrl}
                      onChange={handleChange}
                  />
                  <FormGroup sx={{display:"flex", flexDirection:"row"}}>
                      <FormControlLabel
                          control={<Checkbox checked={productData.isForMen} onChange={handleChange} name="isForMen" />}
                          label="For Men"
                      />
                      <FormControlLabel
                          control={<Checkbox checked={productData.isForKids} onChange={handleChange} name="isForKids" />}
                          label="For Kids"
                      />
                  </FormGroup>
              </Box>
            <Button onClick={handleSubmit} variant="contained" color="primary">
                New product
            </Button>
        </Box>
    );
};

export default AdminNewProduct;
