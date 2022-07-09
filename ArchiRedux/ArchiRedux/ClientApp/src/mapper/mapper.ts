import {Product} from "../model/product";

export function toProduct(data: any) {
    return new Product(data.id, data.name, data.price, data.isRemoved);
}

export function toProducts(data: any[]) {
    if(data == null) return null;
    return data.map(x => toProduct(x));
}