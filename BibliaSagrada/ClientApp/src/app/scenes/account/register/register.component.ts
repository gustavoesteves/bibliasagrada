import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../auth.service';
import { IUserLogin, IUserRegister } from '../user';
import { IError } from '../../../global/handleError';
import { MessageService } from '../../../message/message.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private accountService: AuthService,
    private router: Router,
    private message: MessageService) {
    this.message.clear();
  }

  ngOnInit() { }

  registerUser(username: string, email: string, password: string, confirmPassword: string): void {
    this.accountService.registerUser({ username, email, password, confirmPassword } as IUserRegister)
      .subscribe((_user: IError | any) => {
        if (_user === null) {
          this.accountService.getToken({ email: username, password: password } as IUserLogin)
            .subscribe((token: IError | any) => {
              if (token != null) {
                this.message.clear();
                this.message.add(token.error);
              } else {
                this.accountService.setUsername(username);
                this.accountService.setLogged(true);
                this.router.navigate(['']);
              }
            });
        } else {
          this.message.clear();
          this.message.add(_user.error);
        }
      });
  }

}
