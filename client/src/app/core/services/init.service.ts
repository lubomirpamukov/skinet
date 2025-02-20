import { inject, Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { forkJoin, of } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class InitService {
  private carService = inject(CartService);
  private accountService = inject(AccountService);
  
  init(){
    const cartId = localStorage.getItem('cart_id');
    const cart$ = cartId ? this.carService.getCart(cartId) : of(null);
    
    return forkJoin({
      cart: cart$,
      user: this.accountService.getUserInfo()
    })
  }
}
