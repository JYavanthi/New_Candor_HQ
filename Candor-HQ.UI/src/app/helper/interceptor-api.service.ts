import { HttpRequest, HttpHandler, HttpInterceptor } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoaderServiceService } from 'app/services/loader-service.service';
import { debug } from 'console';
import { finalize } from 'rxjs';

@Injectable()
export class InterceptorApiService  implements HttpInterceptor{


  private requests: HttpRequest<any>[] = [];

  constructor(private loaderService: LoaderServiceService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    this.requests.push(req);
    this.loaderService.show();

    return next.handle(req).pipe(
      finalize(() => {
        this.requests = this.requests.filter(r => r !== req);
        if (this.requests.length === 0) {
          this.loaderService.hide();
        }
      })
    );
  }
}
