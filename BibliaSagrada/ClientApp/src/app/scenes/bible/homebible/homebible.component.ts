import { Component, OnInit, HostListener } from '@angular/core';
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
        this.bindBible(result);
      });
    });
  }

  ngOnInit() { }

  restValues() {
    this.book = null;
    this.charpter = null;
    this.vercicles = [];
  }

  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'ArrowLeft') { this.previousNext(false); }
    if (event.key === 'ArrowRight') { this.previousNext(true); }
  }

  bindBible(reuslt: any) {
    reuslt.map(values => {
      this.inline = values.inLine;
      this.book = values.bookName;
      this.charpter = values.charpterNumber;
      this.vercicles.push({ vercicleNumber: values.vercicleNumber, vercicleText: values.vercicleText });
    });
  }

  previousNext(value: boolean) {
    this.bible.getPreviousNext(value).subscribe((result: any) => {
      this.restValues();
      this.bindBible(result);
    });
  }

}
