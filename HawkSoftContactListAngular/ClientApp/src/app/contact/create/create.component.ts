import { Component, Inject,  OnInit } from '@angular/core';
import { contactService } from '../contact.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';


import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';

   
@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  
  form: FormGroup;
  _baseUrl: string;
  _http: HttpClient;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(
    public contactService: contactService,
    private router: Router, http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) {
    this._baseUrl = baseUrl;
    this._http = http;
  }


  
  
  ngOnInit(): void {
    this.form = new FormGroup({
      contactId: new FormControl(0),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      address1: new FormControl('', [Validators.required]),
      address2: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),
      state: new FormControl('', [Validators.required]),
      zip: new FormControl('', [Validators.required]),      
      usersHawksoftUserId  : new FormControl(1, Validators.required)
    });
  }
   
  get f(){
    return this.form.controls;
  }
    
  submit(){
    console.log(this.form.value);
    this.contactService.create(this.form.value).subscribe(res => {
         console.log('Contact created successfully!');
      this.router.navigateByUrl('fetch-data');
    })
   
  }
  
}
