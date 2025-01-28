import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/shop/product-details/product-details.component';

export const routes: Routes = [
    {path: 'home', component: HomeComponent, title: 'Home'},
    {path: 'shop', component: ShopComponent, title: 'Shop'},
    {path: 'shop/:id', component: ProductDetailsComponent, title: 'Product Details'},
    {path: '**', redirectTo: 'home', pathMatch: 'full'}
];
