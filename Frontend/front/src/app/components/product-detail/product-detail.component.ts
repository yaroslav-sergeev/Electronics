import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product = new Product();
  //excursion: ExcursionViewModel=new ExcursionViewModel();
  constructor(private productService: ProductService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.getProduct();
  }

  getProduct() {
    const productId = this.route.snapshot.paramMap.get('id');
    this.productService.getProductById(productId).subscribe(data => this.product = data);
  }
}
