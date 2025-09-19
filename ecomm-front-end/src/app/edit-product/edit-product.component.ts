import { Component, OnInit, inject } from '@angular/core';
import { ProductsService, Product } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-product',
  imports: [FormsModule],
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit {
  activeRoute: ActivatedRoute = inject(ActivatedRoute);
  router: Router = inject(Router);
  productsService: ProductsService = inject(ProductsService);

  product!: Product;

  ngOnInit(): void {
    this.activeRoute.paramMap.subscribe(parms => {
      let id = +parms.get("id")!
      this.productsService.getProduct(id).subscribe(product => {
        this.product = product;
      })
    });
  }

  updateProduct() {
    this.productsService.updateProduct(this.product).subscribe(_ => {
      this.router.navigate(['/']);
    });
  }
}
