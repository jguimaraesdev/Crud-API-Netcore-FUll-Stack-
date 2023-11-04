import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VeiculosComponent } from './veiculos.component';

describe('VeiculosComponent', () => {
  let component: VeiculosComponent;
  let fixture: ComponentFixture<VeiculosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VeiculosComponent]
    });
    fixture = TestBed.createComponent(VeiculosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
