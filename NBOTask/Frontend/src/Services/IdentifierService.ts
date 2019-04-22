import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { CodeValue } from 'src/types';
import { Identifiers } from 'src/statics';

@Injectable({
  providedIn: 'root',
})
export class IdentifierService {
  public codeValueToStringIdentifier(value: CodeValue){
    return `${value.code}|${value.value}`;
  }
  public translate(t){
    switch(t){
      case Identifiers.NORWEGIAN_BIRTHDAY_NUMBER:
          return "F/D"
      case Identifiers.NORWEGIAN_ORG_NUMBER:
          return "OrgNr"
      default: 
        return null
    }
  }
}