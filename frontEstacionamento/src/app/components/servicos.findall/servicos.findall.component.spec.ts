import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicosfindAllComponent } from './servicos.findall.component';

describe('ServicosfindAllComponent', () => {
  let component: ServicosfindAllComponent;
  let fixture: ComponentFixture<ServicosfindAllComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServicosfindAllComponent]
    });
    fixture = TestBed.createComponent(ServicosfindAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
