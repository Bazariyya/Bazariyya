import axios from 'axios';

export default class ProductService {

    getProductsSmall() {
		var result = axios.get('showcase/demo/data/products-small.json').then(res => res.data.data);
		return result;
	}

	getProducts() {
		var result = axios.get('./showcase/demo/data/products.json').then(res => res.data.data);
		return result;
    }

    getProductsWithOrdersSmall() {
		return axios.get('showcase/demo/data/products-orders-small.json').then(res => res.data.data);
	}
}
