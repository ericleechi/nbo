import { Component, OnInit  } from '@angular/core';
import {ProductService, IProduct} from '../../Services/ProductService';
import { Observable } from 'rxjs';
@Component({
  selector:'product-list',
  templateUrl: './template.html',
  styleUrls: ['./styles.less']
})
export default class ProductList implements OnInit  {
  private productList:IProduct[] = []
  constructor(private productService: ProductService){
  }

  ngOnInit(){
    this.productService.currentList.subscribe((value)=>{
      this.productList = value
    })
  }

}
