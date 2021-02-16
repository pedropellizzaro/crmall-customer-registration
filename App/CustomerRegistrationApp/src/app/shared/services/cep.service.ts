import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CepService {

  constructor(private client: HttpClient) { }

  consultarCep(cep: string) {

    cep = cep.replace(/\D/g, '');

    const validarCep = /^[0-9]{8}$/;

    if (validarCep.test(cep)) {
      return this.client.get(`//viacep.com.br/ws/${cep}/json`);
    }

    return of ({});
  }
}
