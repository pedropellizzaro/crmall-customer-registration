import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormValidations } from 'src/app/shared/form-validations';
import { CepService } from 'src/app/shared/services/cep.service';
import { CustomerService } from 'src/app/shared/services/customer.service';
import { DropdownService } from 'src/app/shared/services/dropdown.service';
import { ToastrService } from 'ngx-toastr';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
  preserveWhitespaces: true
})
export class FormComponent implements OnInit {

  form!: FormGroup;
  genders!: any[];

  constructor(
    private formBuilder: FormBuilder,
    private cepService: CepService,
    private dropdownService: DropdownService,
    private customerService: CustomerService,
    private toastrService: ToastrService,
    private location: Location,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {

    const customer = this.route.snapshot.data['customer'];

    this.genders = this.dropdownService.getGenders();

    this.form = this.formBuilder.group({
      id: [customer.id],
      name: [customer.name, [Validators.required, Validators.maxLength(80), Validators.minLength(3)]],
      birthDate: [customer.birthDate, Validators.required],
      gender: [customer.gender, Validators.required],
      zipCode: [customer.zipCode, FormValidations.cepValidator],
      address: [customer.address],
      number: [customer.number],
      complement: [customer.complement],
      area: [customer.area],
      state: [customer.state],
      city: [customer.city]
    });
  }

  onSubmit() {
    console.log(this.form);

    let msgSuccess = 'Cliente cadastrado com sucesso.';
    let msgError = 'Erro ao cadastrar cliente, tente novamente.';

    if (this.form.value.id) {
      msgSuccess = 'Cliente atualizado com sucesso.';
      msgError = 'Erro ao atualizar cliente, tente novamente.';
    }

    this.customerService.save(this.form.value).subscribe(
      success => {
        this.toastrService.success(msgSuccess);
        this.location.back();
      },
      error => this.toastrService.error(msgError)
    );
  }

  onCancel() {
    this.form.reset();
  }

  onBack() {
    this.location.back();
  }

  verificarValidTouched(field: string) {

    return !this.form.get(field)!.valid
      && (this.form.get(field)!.touched || this.form.get(field)!.dirty);
  }

  aplicarCssErro(field: string) {
    return {
      'has-error': this.verificarValidTouched(field),
      'has-feedback': this.verificarValidTouched(field)
    };
  }

  consultarCEP() {
    const cep = this.form.get('zipCode')!.value;

    if(cep != null && cep !== '') {
      this.cepService.consultarCep(cep)!
        .subscribe(data => this.populateFormAddressData(data));
    }
  }

  resetarDadosForm() {
    this.form.patchValue({
      address: null,
      complement: null,
      area: null,
      city: null,
      state: null
    });
  }

  populateFormAddressData(data: any) {
    this.form.patchValue({
      address: data.logradouro,
      complement: data.complemento,
      area: data.bairro,
      city: data.localidade,
      state: data.uf
    });
  }
}
