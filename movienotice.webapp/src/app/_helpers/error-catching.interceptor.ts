import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError} from "rxjs/operators";
import { HandleErrorService } from '../_services/errorCatching/error-catching.service';

@Injectable()
export class ErrorCatchingInterceptor implements HttpInterceptor {

    constructor(private error: HandleErrorService) {
    }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    this.error.handleError(error)
                    return throwError(error);
                })
            )
    }
}

export const errorCatchingInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: ErrorCatchingInterceptor, multi: true }
];