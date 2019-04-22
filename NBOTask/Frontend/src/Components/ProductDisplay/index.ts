import { Component, OnInit ,Input } from '@angular/core';
import {ProductService, IProduct} from '../../Services/ProductService';
import { MatSnackBar,MatDialog,MatDialogRef } from '@angular/material';

interface IFeedbackResponseResult{
  feedback:string,
  accepted:boolean,
  rating:number
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'feedbackDialog.html',
  styleUrls: ['./styles.less']
})
export class FeedbackDialog {
  @Input() public feedback:string = null
  @Input() public rating:number = null

  constructor(
    public dialogRef: MatDialogRef<ProductDisplay>) {}
  
  onNoClick(): void {
    this.dialogRef.close({
      feedback:this.feedback,
      rating:this.rating,
      accepted:false
    });
  }
  onYesClick(): void {
    this.dialogRef.close({
      feedback:this.feedback,
      rating:this.rating,
      accepted:true
    });
  }

}


@Component({
  selector:'product-display',
  templateUrl: './template.html',
  styleUrls: ['./styles.less']
})
export default class ProductDisplay implements OnInit  {
  private product: IProduct = null;

  constructor(private productService: ProductService,private snackBar: MatSnackBar,private dialog: MatDialog){
  }

  ngOnInit(){
    this.productService.currentProduct.subscribe((value)=>{
      this.product = value;
    })
  }
  
  private sendFeedback(){
    const dialogRef = this.dialog.open(FeedbackDialog, {
      width: '350px'
    });
    dialogRef.afterClosed().subscribe( async (result: IFeedbackResponseResult) => {
        const products = await this.productService.sendFeedback(result.feedback,result.rating,result.accepted);
        this.snackBar.open(`Feedback sent , ${products.length} new Offers`, null, {
          duration: 2000,
        });

   
    });

  
  }

}
