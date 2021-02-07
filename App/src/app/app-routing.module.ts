import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UsersComponent } from './users/users.component';
import { UsersDetailComponent } from './users-detail/users-detail.component';
import { UsersNewComponent } from './users-new/users-new.component';
import { UsersUpdateComponent } from './users-update/users-update.component';

import { CurrentaccountComponent } from './currentaccount/currentaccount.component';
import { CurrentaccountDepositComponent } from './currentaccount-deposit/currentaccount-deposit.component';
import { CurrentaccountPaymentComponent } from './currentaccount-payment/currentaccount-payment.component';
import { CurrentaccountTransferComponent } from './currentaccount-transfer/currentaccount-transfer.component';
import { CurrentaccountWithdrawComponent } from './currentaccount-withdraw/currentaccount-withdraw.component';

import { HistoriccurrentaccountComponent } from './historiccurrentaccount/historiccurrentaccount.component';

const routes: Routes = [
  {
    path: 'users',
    component: UsersComponent,
    data: { title: 'Lista de usuários' }
  },
  {
    path: 'users-detail/:id',
    component: UsersDetailComponent,
    data: { title: 'Detalhe do usuário' }
  },
  {
    path: 'users-new',
    component: UsersNewComponent,
    data: { title: 'Adicionar usuário' }
  },
  {
    path: 'users-update/:id',
    component: UsersUpdateComponent,
    data: { title: 'Editar o usuário' }
  },
  {
    path: 'currentaccount/:id',
    component: CurrentaccountComponent,
    data: { title: 'Conta corrente' }
  },
  {
    path: 'currentaccount-deposit/:id',
    component: CurrentaccountDepositComponent,
    data: { title: 'Depósito' }
  },
  {
    path: 'currentaccount-payment/:id',
    component: CurrentaccountPaymentComponent,
    data: { title: 'Pagamento' }
  },
  {
    path: 'currentaccount-transfer/:id',
    component: CurrentaccountTransferComponent,
    data: { title: 'Transferência' }
  },
  {
    path: 'currentaccount-withdraw/:id',
    component: CurrentaccountWithdrawComponent,
    data: { title: 'Retirada' }
  },
  {
    path: '',
    redirectTo: '/users',
    pathMatch: 'full'
  },
  {
    path: 'historiccurrentaccount/:id',
    component: HistoriccurrentaccountComponent,
    data: { title: 'Histórico' }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
