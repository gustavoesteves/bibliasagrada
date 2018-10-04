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

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Register', component: RegisterComponent },
  { path: 'ForgetPassword', component: ForgetpasswordComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'ChangePassword', component: ChangepasswordComponent },
  { path: 'Manage', component: ManageComponent },
  { path: 'Bible', component: HomebibleComponent },
  { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
