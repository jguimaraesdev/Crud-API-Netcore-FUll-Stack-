
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  
})

export class AppComponent {
  title = 'frontEstacionamento';

  empresaForm = this.fb.group({
    controlEmpresa: ['']
  });

  constructor(public fb: FormBuilder) { }

  onSubmit() {
    alert(JSON.stringify(this.empresaForm.value))
  }
}
