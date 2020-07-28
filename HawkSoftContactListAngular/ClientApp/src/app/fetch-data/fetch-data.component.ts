import { Component, Inject,OnDestroy, OnInit  } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { contactService } from '../../app/contact/contact.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnDestroy, OnInit {
  public contactsHawksoft: ContactsHawksoft[];
  dtOptions: DataTables.Settings = {};
  _baseUrl: string;
  _http: HttpClient;
  dtTrigger: Subject<any> = new Subject();
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, public contactService: contactService, private router: Router) {

    this._baseUrl=baseUrl;
    this._http=http;   
    
  }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2
    };   

    this._http.get<ContactsHawksoft[]>(this._baseUrl + 'api/ContactsHawksofts').subscribe(result => {
      this.contactsHawksoft = result;
        
      }, error => console.error(error));
      
  }

  ngAfterViewInit(): void {
    this.dtTrigger.next();
  }
  
  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  initDataTableOptions(): void {
    this.dtOptions = {
      searching: false,
      paging: false,
      orderCellsTop: true,
     // columns: this.columnSettings,
      language: { emptyTable: 'Not data'}
    }
  }

  deletePost(id) {
    this.contactService.delete(id).subscribe(res => {
     // this.contacts = this.contacts.filter(item => item.ContactId !== id);
      console.log('Post deleted successfully!');
      this._http.get<ContactsHawksoft[]>(this._baseUrl + 'api/ContactsHawksofts').subscribe(result => {
        this.contactsHawksoft = result;

      }, error => console.error(error));

    })
  }
}


interface ContactsHawksoft {
  ContactId : number;  
  FirstName : string;
  LastName  : string;
  Email     : string;
  Address1  : string;
  Address2  : string;
  City      : string;
  State     : string;
  Zip: string;
  UsersHawksoftUserId: number;
}
