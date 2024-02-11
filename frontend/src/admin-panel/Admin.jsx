import React from 'react';
import {Box, Container} from "@mui/material";
import AdminOrder from "./order/AdminOrder";

const Admin = () => {

    return (
        <Box sx={{minHeight:"600px"}}>
            <Container>
               <AdminOrder/>
            </Container>
        </Box>
    );
};

export default Admin;