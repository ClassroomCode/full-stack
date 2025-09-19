import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export class Product {
  productID!: number
  productName!: string
  unitPrice!: number
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl = "http://localhost:5000";

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/products`);
  }

  getProduct( id: number ): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + `/product/${id}` );
  }

  deleteProduct( id: number ): Observable<any> {
    const httpOptions = { //  Create options object
      headers: new HttpHeaders({ //  Create HttpHeaders
        'Authorization': `Basic YWJjMTIz` // Example Auth header
      })
    };
    return this.http.delete<Product>(this.baseUrl + `/product/${id}`, httpOptions);
  }

  addProduct( product: Product ): Observable<any> {
    return this.http.post<Product>(this.baseUrl + '/product', product);
  }

  updateProduct( product: Product ): Observable<any> {
    return this.http.patch<Product>(this.baseUrl + `/product/${product.productID}`, product);
  }
}
