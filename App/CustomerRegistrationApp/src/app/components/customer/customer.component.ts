import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable, Subject, EMPTY } from 'rxjs';
import { catchError, switchMap, take } from 'rxjs/operators';
import { AlertModalService } from 'src/app/shared/alert-modal.service';
import { Customer } from 'src/app/shared/customer';
import { CustomerService } from 'src/app/shared/services/customer.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  preserveWhitespaces: true
})
export class CustomerComponent implements OnInit {

  deleteModalRef: BsModalRef;
  @ViewChild('deleteModal') deleteModal: any;

  customers$: Observable<Customer[]>;
  error$ = new Subject<boolean>();

  constructor(
    private customerService: CustomerService,
    private spinner: NgxSpinnerService,
    private alertService: AlertModalService,
    private toastrService: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.refresh();
  }

  refresh() {
    this.customers$ = this.customerService.get()
    .pipe(
      catchError(error => {
        console.log(error);
        this.handleError();
        return EMPTY;
      })
    );

    this.spinner.show(undefined, {
      type: 'ball-clip-rotate-multiple'
    });

    setTimeout(() => {
      this.spinner.hide();
    }, 400);
  }

  onEdit(id: number) {
    this.router.navigate(['editar', id], { relativeTo: this.route });
  }

  onDelete(customer: Customer) {

    const result$ = this.alertService.showConfirmModal('Excluir cliente', 'Tem certeza que deseja excluir este cliente?');
    result$.asObservable().pipe(
      take(1),
      switchMap(result => result ? this.customerService.delete(customer.id) : EMPTY)
    )
    .subscribe(
      success => {
        this.toastrService.info('Cliente excluído com sucesso.');
        this.refresh();
      },
      error => this.toastrService.error('Erro ao excluir do cliente, tente novamente.')
    );
  }

  handleError() {
    this.alertService.showAlertDanger('Erro ao buscar clientes. Verifique se a API está rodando ou se ela está na porta referenciada e recarregue a página.')
  }

}
