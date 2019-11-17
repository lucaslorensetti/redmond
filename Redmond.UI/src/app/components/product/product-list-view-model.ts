import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { skip, debounceTime, distinctUntilChanged, map } from 'rxjs/operators';
import { ProductModel } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';
import { OnInit, OnDestroy } from '@angular/core';

export class ProductListViewModel {

  private subscription = new Subscription();
  private products: ProductModel[] = [];
  private name$ = new BehaviorSubject<string>(null);

  constructor(private productService: ProductService) {
  }

  initialize(): void {
    this.subscription.add(
      this.onNameChange()
        .subscribe(() => this.load())
    );

    this.load();
  }

  finalize(): void {
    this.subscription.unsubscribe();
  }

  public getProducts(): ProductModel[] {
    return this.products;
  }

  public setName(name: string): void {
    this.name$.next(name);
  }

  public getName(): string {
    return this.name$.value;
  }

  public delete(productId: string): void {
    this.productService.delete(productId)
      .subscribe(() => this.load());
  }

  public load(): void {
    this.productService.getAll(this.getName())
      .subscribe(products => this.products = products);
  }

  private onNameChange(): Observable<void> {
    return this.name$
      .pipe(
        skip(1),
        debounceTime(1000),
        distinctUntilChanged(),
        map(() => { })
      );
  }
}
