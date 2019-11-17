import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { ProductModel } from '../models/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly endpoint = '/Product';

  constructor(private apiService: ApiService) { }

  getAll(name: string): Observable<ProductModel[]> {
    return this.apiService.get<ProductModel[]>(`${this.endpoint}?name=${name || ''}`);
  }

  get(productId: string): Observable<ProductModel> {
    return this.apiService.get<ProductModel>(`${this.endpoint}/${productId}`);
  }

  save(product: ProductModel): Observable<string> {
    return !product.productId
      ? this.apiService.post<string>(this.endpoint, product)
      : this.apiService.put<string>(this.endpoint, product);
  }

  delete(productId: string): Observable<any> {
    return this.apiService.delete(`${this.endpoint}/${productId}`);
  }
}
