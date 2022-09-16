import axios from 'axios';

const instance = axios.create({
    baseURL: process.env.BASE_URL_API
});

instance.defaults.headers.common['Authorization'] = localStorage.getItem("vinhlab_accessToken");

instance.interceptors.request.use(
    config => {
        if (!config.headers.Authorization) {
            const token = JSON.parse(localStorage.getItem("vinhlab_accessToken")).token;

            if (token) {
                config.headers.Authorization = `Bearer ${token}`;
            }
        }

        return config;
    },
    error => Promise.reject(error)
);

instance.interceptors.response.use(response => {
    console.log(response);
    // Edit response config
    return response;
}, error => {
    console.log(error);
    return Promise.reject(error);
});

export default instance;