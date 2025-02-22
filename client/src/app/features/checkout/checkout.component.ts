import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { OrderSummaryComponent } from '../../shared/components/order-summary/order-summary.component';
import { MatStepperModule } from '@angular/material/stepper';
import { RouterLink } from '@angular/router';
import { MatButton } from '@angular/material/button';
import { StripeService } from '../../core/services/stripe.service';
import { StripeAddressElement } from '@stripe/stripe-js';
import { SnackbarService } from '../../core/services/snackbar.service';

@Component({
  selector: 'app-checkout',
  imports: [
    OrderSummaryComponent,
    MatStepperModule,
    RouterLink,
    MatButton
  ],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent implements OnInit, OnDestroy {
  
  private stripeService = inject(StripeService);
  addressElement?: StripeAddressElement;
  private snack = inject(SnackbarService);

  async ngOnInit() {
    
    try {
      this.addressElement = await this.stripeService.createAddressElement()  
      this.addressElement.mount('#address-element');
    } catch (error: any) {
      this.snack.error(error.message)
    }
  }

  ngOnDestroy() {
    this.stripeService.disposeElements();
  }
}
