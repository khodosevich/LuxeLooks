import axios from "axios";

export const api = axios.create({
    baseURL: "http://localhost:5219/",
});


export const method = {

    async register(data) {
        await api.post("Account/Register", data)
    },
    async login(data){

        let value = {} ;
        await api.post("Account/Login", data).then(r => {
            console.log( r.data)
            value = r.data
        })
        return value;
    },
    async getAllProduct() {
        return await api.get('Product/GetAll')
    }

}