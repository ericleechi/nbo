import { Component, OnInit , Input } from '@angular/core';
import {CustomerService, ICustomer} from '../../Services/CustomerService';
import { ProductService } from 'src/Services/ProductService';
import { CodeValue } from 'src/types';
@Component({
  selector:'code-value-display',
  templateUrl: './template.html',
  styleUrls: ['./styles.less']
})
export default class CodeValueDisplay {
  @Input('codeValue') codeValue: CodeValue
  constructor(){
  }

 
}
