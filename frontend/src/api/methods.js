import axios from "axios";

export const api = axios.create({
    // withCredentials:true,
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
        return api.get(`/Product/GetById/${id}`).then(r => {
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
            console.log(response); // Обработка успешного ответа
            return response;
        } catch (error) {
            console.error(error);
            throw error;
        }
    },
    async addToCart(userToken) {
        const data = {
            "Id": "b3ee6ca1-af23-41a9-b567-4d765550c885"
        };
        try {
            const response = await api.put('/Cart/AddToCart', data, {
                headers: {
                    'Authorization': `Bearer ${userToken}`
                }
            });
            console.log(response);
            return response;
        } catch (error) {
            console.error(error);
            throw error;
        }
    },

}