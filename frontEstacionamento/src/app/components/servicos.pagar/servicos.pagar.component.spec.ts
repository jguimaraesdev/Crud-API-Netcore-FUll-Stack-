import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicosPagarComponent } from './servicos.pagar.component';

describe('ServicosPagarComponent', () => {
  let component: ServicosPagarComponent;
  let fixture: ComponentFixture<ServicosPagarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServicosPagarComponent]
    });
    fixture = TestBed.createComponent(ServicosPagarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
