import Axios from 'axios'

function Ajax() {
    const instance = Axios.create({
        baseURL : 'http://localhost:49888/api/',
        timeout: 10000
    });

    return {
        get: (url) => instance.get(url),
        post: (url, data) => instance.post(url, data),
        delete: (url) => instance.delete(url),
        put: (url, data) => instance.put(url, data),
        uploadFile: (url, data) => instance.post(url, data, { headers: { 'Content-Type': 'multipart/form-data' } })
    }
}

export default Ajax();