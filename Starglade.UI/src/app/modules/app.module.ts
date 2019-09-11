import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {StargladeMaterialModule} from './starglade-material.module';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from '../components/app.component';
import { HeaderComponent } from '../components/header/header.component';
import { FooterComponent } from '../components/footer/footer.component';
import { BodyComponent } from '../components/body/body.component';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { BlogListComponent } from '../components/blog-list/blog-list.component';
import { BlogSummaryComponent } from '../components/blog-summary/blog-summary.component';
import { BlogDetailsComponent } from '../components/blog-details/blog-details.component';
import { AboutComponent } from '../components/about/about.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BodyComponent,
    SidebarComponent,
    BlogListComponent,
    BlogSummaryComponent,
    BlogDetailsComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    StargladeMaterialModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
