import { Injectable } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { HttpErrorResponse } from "@angular/common/http";
import { AppSettings } from "src/app/appSettings";

@Injectable({
  providedIn: "root",
})
export class HandleErrorService {
  constructor(private toasters: ToastrService) {}

  // Handling HTTP Errors using Toaster
  public handleError(err: HttpErrorResponse) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      console.log(err);
      switch (err.status) {
        case 400:
          errorMessage = "Bad Request.";
          break;
        case 401:
          if(err.url == AppSettings._API_URL + 'account/login') {
            errorMessage = "Niepoprawne dane logowanie";
          }
          else {
            errorMessage = "Musisz być zalogowany aby wykonać tę akcję.";
          }
          break;
        case 403:
          errorMessage = "Nie masz uprawnień do wykonania tej akcji.";
          break;
        case 404:
          errorMessage = "Akcja nie istnieje.";
          break;
        case 500:
          errorMessage = "Wewnętrzny błąd serwera.";
          break;
        case 503:
          errorMessage = "Żądana usługa jest niedostępna.";
          break;
        default:
          errorMessage = "Coś poszło nie tak!";
      }
    }
    if (errorMessage) {
      this.toasters.error(errorMessage, 'Błąd', { closeButton: true});
    }
  }
}