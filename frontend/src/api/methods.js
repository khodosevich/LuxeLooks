import axios from "axios";

export const api = axios.create({
    withCredentials:true,
    baseURL: "http://localhost:5219/",
});


export const method = {

    async register(data) {
        let value = {} ;
        await api.post("Account/Register", data).then(r => {
            value = r.data
        })

        return value;
    },
    async login(data){

        let value = {} ;
        await api.post("Account/Login", data).then(r => {
            value = r.data
        })

        return value;
    },
    async getAllProduct() {
        return await api.get("Product/GetAll").then(r => {
            return r.data
        })
    },

    async subscribe(data){
        await api.put("Subscribe/CreateSubscribe",data)
    },

    async getPopularProducts() {
        return await api.get("Product/GetPopularProducts").then(r => {
            return r.data
        })
    },
    async getProductById(id) {
        console.log("1111" , id)
        return api.get(`/Product/GetById/${id}`).then(r => {
            console.log(r.data)
            return r.data
        })
    },
    async getProductByName(name) {
        return api.get(`/Product/GetByName/${name}`).then(r => {
            return r.data
        })
    },
    async getCart(userToken) {
        console.log(userToken)
        try {
            const response = await api.get('/Cart/GetCart', {
                headers: {
                    'Authorization': `Bearer ${userToken}`,
                    'Content-Type': 'application/json'
                }
            });
            return response.data;
        } catch (error) {
            console.error(error);
            throw error;
        }
    },
    async addToCart(productId,userToken) {
        const data = {
            "Id": productId
        };
        try {
            const response = await api.put('/Cart/AddToCart', data, {
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }
            });
            return response.data;
        } catch (error) {
            console.error(error);
            throw error;
        }
    },
    async removeFromCart(productId, userToken) {

        try {
            const response = await api.delete(`/Cart/RemoveFromCart`, {
                data: {
                    "Id": productId
                },
                headers: {
                    'Authorization': `Bearer ${userToken}`,
                    'Content-Type': 'application/json'
                },
            });

            return response.data;
        } catch (error) {
            console.error(error);
            throw error;
        }
    },
    async getOrderById(userId, userToken) {

        try{
            const response = await api.get(`/Order/GetOrderByUserId/${userId}`, {
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }
            });
            return response.data;
        }catch (error){
            console.log("Error: " , error)
        }
    },
    async createOrder(data ,userToken) {

        console.log("create order : " , data)

        try{
            const response = await api.post(`/Order/CreateOrder`,
                data
            ,{
                headers: {
                    'Authorization': `Bearer ${userToken}`
                },

            });
            return response.data;
        }catch (error){
            console.log("Error: " , error)
        }
    }

}