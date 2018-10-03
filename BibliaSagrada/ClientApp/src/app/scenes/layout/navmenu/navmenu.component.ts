import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../account/auth.service';
import { IError } from '../../../global/handleError';

@Component({
  selector: 'app-navmenu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavmenuComponent implements OnInit {
  collapsed = true;
  username: string;
  show: boolean;

  constructor(private accountService: AuthService) {
    this.accountService._logged.subscribe(result => {
      this.show = result;
    });
    this.accountService._username.subscribe(result => {
      this.username = result;
    });
  }

  ngOnInit() {
    this.accountService.validateCookie().subscribe((result: any) => {
      if (result.error.text !== undefined) {
        this.accountService.setUsername(result.error.text);
        this.accountService.setLogged(true);
      }
    });
  }

  toggleCollapsed(): void {
    this.collapsed = !this.collapsed;
  }

  userLogout(): void {
    this.accountService.postLogOut().subscribe((logout: IError | any) => {
      if (logout === null) {
        this.accountService.setUsername('');
        this.accountService.setLogged(false);
      }
    });
  }
}
