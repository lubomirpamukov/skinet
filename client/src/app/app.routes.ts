import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/shop/product-details/product-details.component';
import { TestErrorComponent } from './features/test-error/test-error.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { CartComponent } from './features/cart/cart.component';
import { CheckoutComponent } from './features/checkout/checkout.component';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';
import { authGuard } from './core/guards/auth.guard';
import { cartGuard } from './core/guards/cart.guard';
import { EmptyStateComponent } from './shared/components/empty-state/empty-state.component';

export const routes: Routes = [
    {path: 'home', component: HomeComponent, title: 'Home'},
    {path: 'shop', component: ShopComponent, title: 'Shop'},
    {path: 'shop/:id', component: ProductDetailsComponent, title: 'Product Details'},
    {path: 'cart', component: CartComponent, title: 'Cart'},
    {path: 'checkout', component: CheckoutComponent, canActivate: [authGuard, cartGuard], title: 'Checkout'},
    {path: 'account/login', component: LoginComponent, title: 'Login'},
    {path: 'account/register', component: RegisterComponent, title: 'Register'},
    {path: 'test-error', component: TestErrorComponent, title: 'Error Test'},
    {path: 'not-found', component: NotFoundComponent, title: 'Not found'},
    {path: 'server-error', component: ServerErrorComponent, title: 'Server error'},
    {path: '**', redirectTo: 'not-found', pathMatch: 'full'}
];
