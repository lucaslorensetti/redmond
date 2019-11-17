import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ProductDetailComponent } from './product-detail.component';
import { simpleInjector } from 'src/app/helpers/injector-helper';
import { ProductService } from 'src/app/services/product.service';
import { ProductListViewModel } from './product-list-view-model';
import { faPencilAlt, faTrashAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {

  private modalSettings: NgbModalOptions = { size: 'lg', backdrop: 'static', centered: true };

  public faPencilAlt = faPencilAlt;
  public faTrashAlt = faTrashAlt;
  public vm: ProductListViewModel;

  constructor(
    productService: ProductService,
    private modal: NgbModal) {
    this.vm = new ProductListViewModel(productService);
  }

  public ngOnInit(): void {
    this.vm.initialize();
  }

  public ngOnDestroy(): void {
    this.vm.finalize();
  }

  public add(): void {
    this.modal.open(ProductDetailComponent, this.modalSettings).result.then(() => this.vm.load());
  }

  public edit(productId: string): void {
    const options = { ...this.modalSettings, injector: simpleInjector('productId', productId) };
    this.modal.open(ProductDetailComponent, options).result.then(() => this.vm.load());
  }

  public delete(productId: string): void {
    this.vm.delete(productId);
  }
}
