import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoriccurrentaccountComponent } from './historiccurrentaccount.component';

describe('HistoriccurrentaccountComponent', () => {
  let component: HistoriccurrentaccountComponent;
  let fixture: ComponentFixture<HistoriccurrentaccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoriccurrentaccountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoriccurrentaccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
