import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  constructor() { }

  getGenders() {
    return [
      { value: 'F', desc: "Feminino" },
      { value: 'M', desc: "Masculino" }
    ];
  }
}
