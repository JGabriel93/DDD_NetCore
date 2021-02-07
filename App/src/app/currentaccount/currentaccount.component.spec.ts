import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentaccountComponent } from './currentaccount.component';

describe('CurrentaccountComponent', () => {
  let component: CurrentaccountComponent;
  let fixture: ComponentFixture<CurrentaccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentaccountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentaccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
