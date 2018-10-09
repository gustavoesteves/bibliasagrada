import { Component, OnInit } from '@angular/core';
import { BibleService } from '../bible.service';
import { IVercicle } from '../bible';

@Component({
  selector: 'app-homebible',
  templateUrl: './homebible.component.html',
  styleUrls: ['./homebible.component.css']
})
export class HomebibleComponent implements OnInit {

  inline: boolean;
  book: string;
  charpter: number;
  vercicles: IVercicle[] = [];

  constructor(private bible: BibleService) {
    this.bible._checkInline.subscribe(result => {
      this.inline = result;
    });
    this.bible._rangeValue.subscribe(_ => {
      this.bible.getUserVercicles().subscribe((result: any) => {
        this.restValues();
        result.map(values => {
          this.inline = values.inLine;
          this.book = values.bookName;
          this.charpter = values.charpterNumber;
          this.vercicles.push({ vercicleNumber: values.vercicleNumber, vercicleText: values.vercicleText });
        });
      });
    });
  }

  ngOnInit() { }

  restValues() {
    this.book = null;
    this.charpter = null;
    this.vercicles = [];
  }

}
