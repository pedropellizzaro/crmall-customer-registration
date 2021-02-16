import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { tap, delay, take } from 'rxjs/operators';
import { Customer } from '../customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

constructor(private client: HttpClient) { }

  readonly baseUrl = environment.baseUrl;

  getById(id: number) {
    return this.client.get<Customer>(`${this.baseUrl}${id}`).pipe(take(1));
  }

  get() {
    return this.client.get<Customer[]>(this.baseUrl).pipe(delay(400), tap(console.log));
  }

  private post(customer: any) {
    return this.client.post(this.baseUrl, customer).pipe(take(1));
  }

  private put(customer: any) {
    return this.client.put(`${this.baseUrl}${customer.id}`, customer).pipe(take(1));
  }

  delete(id: number) {
    return this.client.delete(`${this.baseUrl}${id}`).pipe(take(1));
  }

  save(customer: any) {
    if (customer.id) {
      return this.put(customer);
    }

    return this.post(customer);
  }
}
