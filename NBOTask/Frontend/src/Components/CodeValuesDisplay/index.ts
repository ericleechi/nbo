import { Component, OnInit , Input } from '@angular/core';
import { CodeValue } from 'src/types';
import { IdentifierService } from 'src/Services/IdentifierService';
@Component({
  selector:'code-values-display',
  templateUrl: './template.html',
  styleUrls: ['./styles.less']
})
export default class CodeValuesDisplay {
  @Input('codeValues') codeValues: CodeValue[] = []
  constructor(private identifierService:IdentifierService){
  }

 
}
