import { Component, OnInit } from '@angular/core';
import { IChangePassword } from '../user';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css']
})
export class ChangepasswordComponent implements OnInit {

  constructor(private accountService: AuthService) { }

  ngOnInit() {
  }

  changePassword(oldPassword: string, newPassword: string, confirmPassword: string) {
    this.accountService.changePassword({
      oldPassword: oldPassword,
      newPassword: newPassword,
      confirmPassword: confirmPassword
    } as IChangePassword)
      .subscribe((result: any) => {
        console.log(result);
      });
  }

}
