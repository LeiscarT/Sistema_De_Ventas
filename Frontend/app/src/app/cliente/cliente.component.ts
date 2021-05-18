import { Component, OnInit } from '@angular/core';
import { ApiClienteService } from '../services/api-cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {

  constructor(private apiCliente : ApiClienteService) 
  {
      apiCliente.getClientes().subscribe(Response => console.log(Response));
   }

  ngOnInit(): void {
  }

}
