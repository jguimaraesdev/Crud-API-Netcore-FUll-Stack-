import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicosEditComponent } from './servicos.edit.component';

describe('ServicosEditComponent', () => {
  let component: ServicosEditComponent;
  let fixture: ComponentFixture<ServicosEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ServicosEditComponent]
    });
    fixture = TestBed.createComponent(ServicosEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
