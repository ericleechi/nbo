import { Component, OnInit  } from '@angular/core';
import {CustomerService, ICustomer} from '../../Services/CustomerService';
import { ProductService } from 'src/Services/ProductService';
import { FormControl } from '@angular/forms';
import {groupBy,chain,spread,merge} from 'lodash'
import { CodeValue } from 'src/types';
import { IdentifierService } from 'src/Services/IdentifierService';
@Component({
  selector:'customer-list',
  templateUrl: './template.html',
  styleUrls: ['./styles.less']
})
export default class CustomerList implements OnInit {
  private customerList: ICustomer[];
  private groups = new Map<string,ICustomer[]>();
  constructor(private customerService: CustomerService, private identifierService: IdentifierService) {
  }
  async ngOnInit() {
    this.customerList  = await this.customerService.fetchCustomerList();
    this.groups = chain(this.customerList).groupBy((x)=>this.identifierService.codeValueToStringIdentifier(x.type)).value()
  }
}
