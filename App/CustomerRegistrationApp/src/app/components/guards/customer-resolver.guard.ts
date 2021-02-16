import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Customer } from 'src/app/shared/customer';
import { CustomerService } from 'src/app/shared/services/customer.service';

@Injectable({
  providedIn: 'root',
})
export class CustomerResolverGuard implements Resolve<Customer> {

  constructor(private customerService: CustomerService) {}

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> {

    if (route.params && route.params.id) {
      return this.customerService.getById(route.params.id);
    }

    return of({
      id: null,
      name: null,
      birthDate: null,
      gender: null,
      zipCode: null,
      address: null,
      number: null,
      complement: null,
      area: null,
      state: null,
      city: null
    });
  }
}
