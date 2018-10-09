import { Component, OnInit } from '@angular/core';
import { BibleService } from '../bible.service';

@Component({
  selector: 'app-pickone',
  templateUrl: './pickone.component.html',
  styleUrls: ['./pickone.component.css']
})
export class PickoneComponent implements OnInit {

  book: string;
  charpter: string;
  vercicleNumber: number;
  vercicleText: string;

  constructor(private bible: BibleService) { }

  ngOnInit() {
    this.bible.getPickOne().subscribe((result: any) => {
      result.map(values => {
        this.book = values.bookName;
        this.charpter = values.charpterNumber;
        this.vercicleNumber = values.vercicleNumber;
        this.vercicleText = values.vercicleText;
      });
    });
  }

}
