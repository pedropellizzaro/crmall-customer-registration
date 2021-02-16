import { FormControl } from "@angular/forms";

export class FormValidations {

  static cepValidator(control: FormControl) {
    const cep = control.value;
    if (cep && cep !== '') {
      const validarCep = /^[0-9]{8}$/;
      return validarCep.test(cep) ? null : { cepInvalido: true }
    }
    return null;
  }
}
