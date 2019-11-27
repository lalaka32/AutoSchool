import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '../shared/services/AuthService';
import {User} from "../shared/entities/User";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
})
export class RegistrationComponent implements OnInit {
  registrationForm: FormGroup;
  submitClick = false;
  submitted = false;
  returnUrl: string;
  error ='';

  errorMessages = {
    LOGIN_OCCUPIED : 'Login is already taken'
  };

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) { }
  ngOnInit() {
    this.registrationForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
      name: ['', Validators.required],
      address: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required]
    });

    this.authenticationService.logout();

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get formData() { return this.registrationForm.controls; }

  onLogin() {
    this.submitted = true;

    if (this.registrationForm.invalid) {
      return;
    }

    this.submitClick = true;
    let user = new User(null,null,null,this.formData.login.value, this.formData.password.value,
      null, this.formData.name.value, this.formData.address.value, this.formData.email.value, this.formData.phoneNumber.value);
    this.authenticationService.registryUser(user)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          console.log(error);
          this.error = this.errorMessages[error.error.code];
          this.submitClick = false;
        });
  }
}
