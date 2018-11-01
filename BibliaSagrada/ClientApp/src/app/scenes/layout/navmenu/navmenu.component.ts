import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../account/auth.service';
import { IError } from '../../../global/handleError';
import { BibleService } from '../../bible/bible.service';

@Component({
  selector: 'app-navmenu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavmenuComponent implements OnInit {
  collapsed = true;
  username: string;
  show: boolean;
  checkboxInline: boolean;
  rangeValue: number;

  constructor(
    private accountService: AuthService,
    private bible: BibleService,
    private router: Router) {
    this.accountService._logged.subscribe(result => {
      this.show = result;
    });
    this.accountService._username.subscribe(result => {
      this.username = result;
    });
    this.bible._checkInline.subscribe(result => {
      this.checkboxInline = result;
    });
    this.bible._rangeValue.subscribe(result => {
      this.rangeValue = result;
    });
  }

  ngOnInit() { }

  toggleCollapsed(): void {
    this.collapsed = !this.collapsed;
  }

  userLogout(): void {
    this.accountService.postLogOut().subscribe((logout: IError | any) => {
      if (logout === null) {
        this.accountService.setUsername('');
        this.accountService.setLogged(false);
        this.router.navigate(['/Home']);
      }
    });
  }

  checkboxChange() {
    this.accountService.PostChangeInLine().subscribe(_ => {
      this.bible.setCheckInline(!this.checkboxInline);
    });
  }

  onChange(value: number) {
    this.accountService.PostChangeNumberVercicles(value).subscribe(_ => {
      this.bible.setRangeValue(value);
    });
  }

}
