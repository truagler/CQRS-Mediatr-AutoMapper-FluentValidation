export class Product {
    public id: string;
    
    public name: string;
    
    public price: number;

    public isRemoved: boolean;

    constructor(id: string, name: string, price: number, isRemoved: boolean) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.isRemoved = isRemoved;
    }
}