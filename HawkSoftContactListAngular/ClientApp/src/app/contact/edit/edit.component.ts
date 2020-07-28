import { Component, OnInit } from '@angular/core';
import { contactService } from '../contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '../contact';
import { FormGroup, FormControl, Validators} from '@angular/forms';
   
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
    
  id: number;
  contact: Contact;
  form: FormGroup;
  
  constructor(
    public contactService: contactService,
    private route: ActivatedRoute,
    private router: Router
  ) { }
  
  ngOnInit(): void {
    this.id = this.route.snapshot.params['contactId'];
    this.contactService.find(this.id).subscribe((data: Contact)=>{
      this.contact = data;
    });
    
    this.form = new FormGroup({
      title: new FormControl('', [Validators.required]),
      body: new FormControl('', Validators.required)
    });
  }
   
  get f(){
    return this.form.controls;
  }
     
  submit(){
    console.log(this.form.value);
    this.contactService.update(this.id, this.form.value).subscribe(res => {
         console.log('Contact updated successfully!');
         this.router.navigateByUrl('contact/index');
    })
  }
   
}