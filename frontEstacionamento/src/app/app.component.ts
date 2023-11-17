
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  
  
})

export class AppComponent implements OnInit{
  title = 'frontEstacionamento';

  Form = this.fb.group({
    control: ['']
  });

  constructor(public fb: FormBuilder) { }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  onSubmit() {
    alert(JSON.stringify(this.Form.value))
  }
 
}
