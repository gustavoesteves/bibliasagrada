import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PickoneComponent } from './pickone.component';

describe('PickoneComponent', () => {
  let component: PickoneComponent;
  let fixture: ComponentFixture<PickoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PickoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PickoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
