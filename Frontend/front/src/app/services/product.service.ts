import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl='http://localhost:55348/api/products';
  constructor(private http: HttpClient) { }

  getAllProsucts (): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }


}
