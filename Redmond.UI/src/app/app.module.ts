import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { RootComponent } from './components/root/root.component';
import { ProductListComponent } from './components/product/product-list.component';
import { ProductDetailComponent } from './components/product/product-detail.component';

@NgModule({
  declarations: [
    RootComponent,
    ProductListComponent,
    ProductDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [RootComponent],
  entryComponents: [
    ProductDetailComponent
  ]
})
export class AppModule { }
