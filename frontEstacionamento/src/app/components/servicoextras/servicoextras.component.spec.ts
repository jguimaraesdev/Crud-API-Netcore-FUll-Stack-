import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicoextrasComponent } from './servicoextras.component';

describe('ServicoextrasComponent', () => {
  let component: ServicoextrasComponent;
  let fixture: ComponentFixture<ServicoextrasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServicoextrasComponent]
    });
    fixture = TestBed.createComponent(ServicoextrasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
