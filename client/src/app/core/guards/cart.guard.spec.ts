import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { cartGuard } from './cart.guard';

describe('cartGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => cartGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
