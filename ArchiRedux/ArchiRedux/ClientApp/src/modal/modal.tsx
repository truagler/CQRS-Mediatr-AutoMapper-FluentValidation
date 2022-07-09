import {Product} from "../model/product";
import {ChangeEvent, Component} from "react";
import * as React from "react";
import {Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";

type State = {
    product: Product;
}

type Props = {
    isShown: boolean
    close: () => void;
    getProducts: () => void;
    product: Product | null;
}

export class ModalPopup extends Component<Props, State>{
    constructor(props: any) {
        super(props);
        
        this.state = {
            product: {
                id: this.props.product != null ? this.props.product.id : "",
                name: "",
                price: 0,
                isRemoved: false
            }
        }
    }
    
    async addProduct(){
        const axios = require('axios');
        const productDto = {'id': this.state.product.id, 'name': this.state.product.name, 'price': this.state.product.price, 'isRemoved': false };
        const result = await axios.post('/addproduct', productDto);
        if(result.data != null){
            return alert(result.data);
        }
        this.props.close();
        await this.props.getProducts();
    }
    
    async updateProduct(){
        const axios = require('axios');
        const productDto = {'id': this.props.product?.id, 'name': this.state.product.name ?? this.props.product?.name, 'price': this.state.product.price ?? this.props.product?.price, 'isRemoved': false };
        const result = await axios.post('/updateproduct', productDto);
        if(result.data != null){
            return alert(result.data);
        }
        this.props.close();
        await this.props.getProducts();
    }
    
    updateName(e: ChangeEvent<HTMLInputElement>){
        const name = e.target.value.toString();
        this.setState({product: { name: name, isRemoved: false, price: this.state.product.price ?? this.props.product!.price, id: this.props.product?.id ?? ""} })
    }
    
    updatePrice(e: ChangeEvent<HTMLInputElement>){
        const price = Number(e.target.value);
        this.setState({product: { name: this.state.product.name ?? this.props.product!.name, isRemoved: false, price: price, id: this.props.product?.id ?? ""} })
    }
    
    render() {
        return(
            <div>
                <Modal 
                    size="lg" 
                    isOpen={this.props.isShown} 
                    aria-labelledby="contained-modal-title-vcenter" 
                    fade={false}
                >
                    <ModalHeader>
                        <h1>{this.props.product != null ? "Редактирование продукта" : "Добавление продукта"}</h1>
                    </ModalHeader>
                    <ModalBody>
                        <p><b>Наименование: </b> <input onChange={(e) => this.updateName(e)} type="text"/></p>
                        <p><b>Цена: </b><input onChange={(e) => this.updatePrice(e)} type="number"/></p>
                    </ModalBody>
                    <ModalFooter>
                        <button onClick={this.props.product != null ? () => this.updateProduct() : () => this.addProduct()} className="btn btn-success">{this.props.product != null ? "Редактировать" : "Добавить"}</button>
                        <button onClick={() => this.props.close()} className="btn btn-danger">Выйти</button>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
}