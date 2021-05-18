import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http'



@Injectable({
  providedIn: 'root'
})
export class ApiClienteService {

  url: string = "https://localhost:44375/Api/Cliente"
  
  constructor(private _http: HttpClient)
   {
   
   }

   getClientes() : Observable<Response>
   {
      return this._http.get<Response>(this.url);
   }
  
}
