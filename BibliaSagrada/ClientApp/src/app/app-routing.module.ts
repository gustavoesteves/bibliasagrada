import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RegisterComponent } from './scenes/account/register/register.component';
import { LoginComponent } from './scenes/account/login/login.component';
import { HomeComponent } from './scenes/layout/home/home.component';
import { ForgetpasswordComponent } from './scenes/account/forgetpassword/forgetpassword.component';
import { PagenotfoundComponent } from './scenes/layout/pagenotfound/pagenotfound.component';
import { AuthGuard } from './scenes/account/auth.guard';
import { ChangepasswordComponent } from './scenes/account/changepassword/changepassword.component';
import { ManageComponent } from './scenes/account/manage/manage.component';
import { HomebibleComponent } from './scenes/bible/homebible/homebible.component';
import { PickoneComponent } from './scenes/bible/pickone/pickone.component';

const routes: Routes = [
  { path: '', canActivate: [AuthGuard], component: HomebibleComponent },
  { path: 'PickOne', canActivate: [AuthGuard], component: PickoneComponent },
  { path: 'Home', component: HomeComponent },
  { path: 'Register', component: RegisterComponent },
  { path: 'ForgetPassword', component: ForgetpasswordComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'ChangePassword', component: ChangepasswordComponent },
  { path: 'Manage', canActivate: [AuthGuard], component: ManageComponent },
  { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
