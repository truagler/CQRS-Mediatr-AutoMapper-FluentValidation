import { Component } from 'react';
import * as React from "react";
import {Product} from "../model/product";
import {toProduct, toProducts} from "../mapper/mapper";
import {ModalPopup} from "../modal/modal";

type Props = {}

type State = {
  products: Product[] | null;
  product: Product | null;
  isShown: boolean;
}

export class FetchData extends Component<Props, State> {
  constructor(props: any) {
    super(props);
    this.state = {
      products: null,
      product: null,
      isShown: false
    }
  }
  
  componentDidMount() {
    this.getProducts();
  }
  
  async getProducts(){
    const axios = require('axios');
    const result = await axios.get('/getproducts');
    const products = toProducts(result.data.result);
    if(products != null){
      this.setState({products: products});
    }
  }
  
  async getProduct(id: string){
    const axios = require('axios');
    const result = await axios.get('/getproduct', {params: {
      id: id
      }});
    const product = toProduct(result.data.result);
    this.setState({product: product, isShown: true});
  }
  
  onOpen(){
    this.setState({isShown: true, product: null})
  }
  
  onClose(){
    this.setState({isShown: false})
  }
  
  render() {

    return (
      <div>
        <table className='table table-striped'>
          <thead>
          <tr>
            <th>Продукт</th>
            <th>Цена</th>
            <th>Удален/Не удален</th>
            <th><button onClick={() => this.onOpen()} className="btn btn-success">Добавить</button></th>
          </tr>
          </thead>
          <tbody>
          {this.state.products != null && this.state.products.map(prod =>
                  <tr key={prod.id} >
                    <td><b onClick={() => this.getProduct(prod.id)}>{prod.name}</b></td>
                    <td>{prod.price}P</td>
                    <td>{prod.isRemoved ? "Удален" : "Не удален"}</td>
                    <td></td>
                  </tr>
              )
          }
          </tbody>
        </table>
        <ModalPopup getProducts={() => this.getProducts()} isShown={this.state.isShown} close={() => this.onClose()} product={this.state.product}/>
      </div>
    );
  }
}
