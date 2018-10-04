import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavmenuComponent } from './scenes/layout/navmenu/navmenu.component';
import { AppRoutingModule } from './/app-routing.module';
import { LoginComponent } from './scenes/account/login/login.component';
import { RegisterComponent } from './scenes/account/register/register.component';
import { HomeComponent } from './scenes/layout/home/home.component';
import { ForgetpasswordComponent } from './scenes/account/forgetpassword/forgetpassword.component';
import { FooterComponent } from './scenes/layout/footer/footer.component';
import { MessagesComponent } from './message/messages/messages.component';
import { PagenotfoundComponent } from './scenes/layout/pagenotfound/pagenotfound.component';
import { ManageComponent } from './scenes/account/manage/manage.component';
import { ChangepasswordComponent } from './scenes/account/changepassword/changepassword.component';
import { HomebibleComponent } from './scenes/bible/homebible/homebible.component';

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ForgetpasswordComponent,
    FooterComponent,
    MessagesComponent,
    PagenotfoundComponent,
    ManageComponent,
    ChangepasswordComponent,
    HomebibleComponent
  ],
  imports: [
    NgbModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
