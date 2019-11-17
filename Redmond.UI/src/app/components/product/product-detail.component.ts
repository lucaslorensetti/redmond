import { Component, OnInit, Inject, Optional, OnDestroy } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductDetailViewModel } from './product-detail-view-model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit, OnDestroy {

  public vm: ProductDetailViewModel;

  constructor(
    @Inject('productId') @Optional() productId: string,
    productService: ProductService,
    private modal: NgbActiveModal) {
    this.vm = new ProductDetailViewModel(productService, productId);
  }

  ngOnInit(): void {
    this.vm.initialize();
  }
  ngOnDestroy(): void {
    this.vm.finalize();
  }

  public save(): void {
    this.vm.save().subscribe(() => this.close());
  }

  public close(): void {
    this.modal.close();
  }

}
