import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomebibleComponent } from './homebible.component';

describe('HomebibleComponent', () => {
  let component: HomebibleComponent;
  let fixture: ComponentFixture<HomebibleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomebibleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomebibleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
