import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ClientesComponent } from './components/clientes/clientes.component';

describe('ClientesComponent', () => {
  let component: ClientesComponent;
  let fixture: ComponentFixture<ClientesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientesComponent]
    });
    fixture = TestBed.createComponent(ClientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
