import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CreateComponent } from './contact/create/create.component';
import { EditComponent } from './contact/edit/edit.component';  
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,  
    FetchDataComponent,CreateComponent,EditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DataTablesModule, ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },    
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'contact/create', component: CreateComponent },
      { path: 'contact/:contactId/edit', component: EditComponent }, 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
