import { Component, OnInit, inject } from '@angular/core';
import { ProductsService, Product } from '../products.service';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-list',
  imports: [CurrencyPipe],
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
}
