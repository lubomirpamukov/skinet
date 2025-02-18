import { inject, Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InitService {
  private carService = inject(CartService)
  
  init(){
    const cartId = localStorage.getItem('cart_id');
    const cart$ = cartId ? this.carService.getCart(cartId) : of(null);
    
    return cart$;
  }
}
