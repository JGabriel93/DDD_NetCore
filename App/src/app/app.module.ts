import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './menu/menu.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { HttpClientModule } from '@angular/common/http';
import { LayoutModule } from '@angular/cdk/layout';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UsersDetailComponent,
    UsersNewComponent,
    UsersUpdateComponent,
    CurrentaccountComponent,
    CurrentaccountDepositComponent,
    CurrentaccountPaymentComponent,
    CurrentaccountTransferComponent,
    CurrentaccountWithdrawComponent,
    HistoriccurrentaccountComponent,
    MenuComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    MatIconModule,
    MatListModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    MatSidenavModule,
    MatTableModule,
    MatToolbarModule,
    LayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
