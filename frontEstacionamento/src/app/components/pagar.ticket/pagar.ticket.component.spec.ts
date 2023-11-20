import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagarTicketComponent } from './pagar.ticket.component';

describe('PagarTicketComponent', () => {
  let component: PagarTicketComponent;
  let fixture: ComponentFixture<PagarTicketComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PagarTicketComponent]
    });
    fixture = TestBed.createComponent(PagarTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
