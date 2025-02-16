import { HttpInterceptorFn } from '@angular/common/http';
import { delay, finalize } from 'rxjs';
import { BusyService } from '../service/busy.service';
import { inject } from '@angular/core'

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const busyService = inject(BusyService)
  
  busyService.busy();


  return next(req).pipe(
    delay(800),
    finalize(() => busyService.idle())
  )
};
