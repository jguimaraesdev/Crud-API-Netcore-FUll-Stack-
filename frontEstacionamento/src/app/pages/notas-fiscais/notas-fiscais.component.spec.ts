import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotasFiscaisComponent } from './notas-fiscais.component';

describe('NotasFiscaisComponent', () => {
  let component: NotasFiscaisComponent;
  let fixture: ComponentFixture<NotasFiscaisComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NotasFiscaisComponent]
    });
    fixture = TestBed.createComponent(NotasFiscaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
