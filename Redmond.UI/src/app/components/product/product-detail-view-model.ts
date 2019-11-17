import { ProductModel } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

export class ProductDetailViewModel {

  name: string;
  price: number;

  constructor(
    private productService: ProductService,
    private productId: string) { }

  initialize(): void {
    if (this.productId) {
      this.productService.get(this.productId)
        .subscribe(product => this.fromModel(product));
    }
  }

  finalize(): void {

  }

  save(): Observable<string> {
    return this.productService
      .save(this.toModel())
      .pipe(
        tap(productId => this.productId = productId)
      );
  }

  isValid(): boolean {
    return this.nameIsValid()
      && this.priceIsValid();
  }

  nameIsValid(): boolean {
    return this.name
      && this.name.length >= 3;
  }

  priceIsValid(): boolean {
    return this.price
      && this.price > 0;
  }

  fromModel(model: ProductModel): void {
    this.productId = model.productId;
    this.name = model.name;
    this.price = model.price;
  }

  toModel(): ProductModel {
    const model = new ProductModel();
    model.productId = this.productId;
    model.name = this.name;
    model.price = this.price;
    return model;
  }
}
