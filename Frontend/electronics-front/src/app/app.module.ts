import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header/header.component';
import { AppRoutingModule } from './app-routing.module';
import { ListOfProductsComponent } from './list-of-products/list-of-products.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ListOfProductsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MDBBootstrapModule.forRoot()
  ],
  schemas: [ NO_ERRORS_SCHEMA ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
