import React, { useState } from 'react';
import {
    Button,
    Modal,
    TextField,
    Typography,
    Box,
    FormControl,
    Select,
    MenuItem,
    FormGroup,
    FormControlLabel, Checkbox
} from '@mui/material';
import {method} from "../../api/methods";

const ProductEditModal = ({ productData, handleModalClose }) => {

    console.log(productData)

    const {id,price, name, description, type, imageUrl, isForMen, isForKids } = productData;
    const [editedProduct, setEditedProduct] = useState({
        price: price,
        name: name,
        description: description,
        type: type,
        imageUrl: imageUrl,
        isForMen: isForMen,
        isForKids: isForKids,
        id:id
    });

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setEditedProduct(prevData => ({
            ...prevData,
            [name]: type === 'checkbox' ? checked : value
        }));
    };


    const handleSubmit = async () => {

        const token = JSON.parse(localStorage.getItem("token"))

        try {
            const data = await method.admin.updateProduct(token,productData)
            console.log(data)
            handleModalClose(false)
        }catch (e) {
            console.log(e)
        }
    };

    return (
        <Modal
            open={true}
            onClose={() => {}}
            aria-labelledby="modal-title"
            aria-describedby="modal-description"
        >
            <Box sx={{
                position: 'absolute',
                top: '50%',
                left: '50%',
                transform: 'translate(-50%, -50%)',
                bgcolor: 'background.paper',
                boxShadow: 24,
                p: 4,
                width: 900,
                height: 600
            }}>
                <Typography variant={"h4"}>Update product: </Typography>
                <Box sx={{display:"flex" , flexDirection:"column" , gap:"20px", marginTop:"20px"}}>
                    <TextField
                        label="Price"
                        name="price"
                        type="number"
                        value={editedProduct.price}
                        onChange={handleChange}
                    />
                    <TextField
                        label="Name"
                        name="name"
                        value={editedProduct.name}
                        onChange={handleChange}
                    />
                    <TextField
                        label="Description"
                        name="description"
                        value={editedProduct.description}
                        onChange={handleChange}
                    />
                    <FormControl sx={{width:"195px"}} >
                        <Select
                            value={type}
                            onChange={editedProduct.handleChange}
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
                            <MenuItem value="Trousers">Trousers</MenuItem>
                            <MenuItem value="Jacket">Jacket</MenuItem>
                            <MenuItem value="Shirt">Shirt</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        label="Image URL"
                        name="imageUrl"
                        value={editedProduct.imageUrl}
                        onChange={handleChange}
                    />
                    <FormGroup sx={{display:"flex", flexDirection:"row"}}>
                        <FormControlLabel
                            control={<Checkbox checked={editedProduct.isForMen} onChange={handleChange} name="isForMen" />}
                            label="For Men"
                        />
                        <FormControlLabel
                            control={<Checkbox checked={editedProduct.isForKids} onChange={handleChange} name="isForKids" />}
                            label="For Kids"
                        />
                    </FormGroup>
                    <Box sx={{display:"flex" , gap:"20px"}}>
                        <Button onClick={handleSubmit} variant="contained" color="primary">
                            Update product
                        </Button>
                        <Button onClick={() => handleModalClose(false)} sx={{color:"red"}} color="primary">
                            Cancel
                        </Button>
                    </Box>
                </Box>
            </Box>
        </Modal>
    );
};

export default ProductEditModal;
