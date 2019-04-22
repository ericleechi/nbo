import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {CodeValue} from '../types';
import { BehaviorSubject } from 'rxjs';
import { CustomerService } from './CustomerService';

export interface IProduct{
  id: string
  type: CodeValue
}

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  public currentList = new BehaviorSubject<IProduct[]>([])
  public currentProduct = new BehaviorSubject<IProduct>(null)
  constructor(private http: HttpClient, private customerService: CustomerService) {
    this.customerService.subscribeToCustomerChanged((id:string)=>{
      if(id){
        this.selectActiveProduct(null);
        this.fetchSuggestions(id);
      }else{
        this.currentList.next([]);
      }
    })
  }
  public selectActiveProduct(product: IProduct){
    this.currentProduct.next(product)
  }
  public async fetchSuggestions(customerId: string) : Promise<IProduct[]>{
     const result =  await this.http.post<IProduct[]>(`api/nbo/suggestions`,{
       customerId
     }).toPromise();
  
     this.currentList.next(result)
     return result
  }

  public async sendFeedback(feedback:string,rating:number,accepted:boolean){
    const newSuggestions = await this.http.post<IProduct[]>(`api/nbo/feedback`,{
      productId:this.currentProduct.getValue().id,
      feedback,
      rating,
      accepted,
      customerId:this.customerService.selectedValue.getValue()
    }).toPromise();
    this.currentList.next(newSuggestions)
    this.selectActiveProduct(null);
    return newSuggestions
  }

}