import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css']
})
export class ManageComponent implements OnInit {

  rangeValue: number;
  checkboxInline: boolean;

  constructor(private accountService: AuthService) { }

  ngOnInit() {
    this.accountService.manageLogins().subscribe((result: any) => {
      this.rangeValue = result.numbersVercicle;
      this.checkboxInline = result.inlineVercicle;
    });
  }

  onChange(value: number) {
    this.rangeValue = value;
    this.accountService.PostChangeNumberVercicles(value).subscribe();
  }

  checkboxChange() {
    this.checkboxInline = !this.checkboxInline;
    this.accountService.PostChangeInLine().subscribe();
  }

}
