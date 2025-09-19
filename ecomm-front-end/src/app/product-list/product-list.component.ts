import { Component, OnInit, inject } from '@angular/core';
import { ProductsService, Product } from '../products.service';
import { CurrencyPipe } from '@angular/common';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-product-list',
  imports: [CurrencyPipe, RouterLink],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {

  productsService = inject(ProductsService);
  products: Product[] = []
  hasError = false;

  ngOnInit(): void {
    this.productsService.getProducts().subscribe({
      next: (data: Product[]) => {
        this.products = data;
      },
      error: (error) => {
        this.hasError = true;
      }
    });
  }

  deleteProduct(product: Product) {
    this.productsService.deleteProduct(product.productID).subscribe(_ => {
      this.products = this.products.filter(p => p.productID !== product.productID);
    });
  }
}
