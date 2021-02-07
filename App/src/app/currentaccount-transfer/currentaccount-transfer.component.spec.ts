import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentaccountTransferComponent } from './currentaccount-transfer.component';

describe('CurrentaccountTransferComponent', () => {
  let component: CurrentaccountTransferComponent;
  let fixture: ComponentFixture<CurrentaccountTransferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentaccountTransferComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentaccountTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
