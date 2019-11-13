import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from "./login/login.component";
import {AuthorizationCheck} from "./shared/services/AuthorizationCheck";

import {AuthenticationService} from "./shared/services/AuthService";
import {ErrorInterceptor} from "./shared/interceptors/errorInterceptor";
import {httpInterceptor} from "./shared/interceptors/httpInterceptor";
import {RegistrationComponent} from "./registration/registration.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: AppComponent, pathMatch: 'full', canActivate: [AuthorizationCheck]},
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: 'registration', component: RegistrationComponent, pathMatch: 'full' }
    ])
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: httpInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthenticationService, AuthorizationCheck],
  bootstrap: [AppComponent]
})
export class AppModule { }
