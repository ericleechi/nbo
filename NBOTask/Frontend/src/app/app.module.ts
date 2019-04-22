import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CustomerList, ProductList, ProductDisplay,CodeValueDisplay,FeedbackDialog,CodeValuesDisplay} from '../Components';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, 
  MatIconModule,
  MatCheckboxModule,
  MatOptionModule, 
  MatListModule,
  MatRadioModule,
  MatSelectModule,
  MatCardModule,
  MatChipsModule, 
  MatToolbarModule,
  MatSnackBarModule,
  MatInputModule,
  MatButtonToggleModule,
  MatCommonModule,
  MatDialogModule } from '@angular/material';
@NgModule({
  declarations: [
    AppComponent,
    CustomerList,
    ProductList,
    ProductDisplay,
    CodeValueDisplay,
    CodeValuesDisplay,
    FeedbackDialog
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule, 
    MatCheckboxModule, 
    MatOptionModule, 
    MatListModule,
    MatRadioModule,
    MatSelectModule,
    MatCardModule,
    MatChipsModule,
    MatToolbarModule,
    MatSnackBarModule,
    MatInputModule,
    MatDialogModule,
    MatButtonToggleModule,
    MatIconModule,
    MatCommonModule
  ],
  entryComponents:[FeedbackDialog],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
