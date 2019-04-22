import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BehaviorSubject } from 'rxjs';
import { CodeValue } from 'src/types';

export interface ICustomer{
  id: string
  type: CodeValue
}
@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  public selectedValue = new BehaviorSubject<string>(null);
  constructor(private http: HttpClient) {

  }

  public subscribeToCustomerChanged(callback:(customerId:string)=>void){
    this.selectedValue.subscribe((customerId)=>{
      callback(customerId)
    })
  }
  public setActiveCustomer(customerId:string){
    this.selectedValue.next(customerId)
  }
  public fetchCustomerList() : Promise<ICustomer[]>{
     const result =  this.http.get<ICustomer[]>(`api/customer/search`).toPromise();
    
     return result
  }
}