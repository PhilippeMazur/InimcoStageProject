import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { OverviewComponent } from './overview/overview.component';
import { RouterModule } from '@angular/router';
import { CreatePersonComponent } from './create-person/create-person.component';
import { ChangePersonComponent } from './change-person/change-person.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    OverviewComponent,
    CreatePersonComponent,
    ChangePersonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: OverviewComponent },
      { path: 'overview', component: OverviewComponent},
      { path: 'create', component: CreatePersonComponent },
      { path: 'change/:id', component: ChangePersonComponent }
    ]),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
