import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketsFindallComponent } from './tickets.findall.component';

describe('TicketsFindallComponent', () => {
  let component: TicketsFindallComponent;
  let fixture: ComponentFixture<TicketsFindallComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TicketsFindallComponent]
    });
    fixture = TestBed.createComponent(TicketsFindallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
