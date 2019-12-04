import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {StargladeMaterialModule} from './starglade-material.module';
import { AppRoutingModule } from './app-routing.module';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from '../components/app.component';
import { HeaderComponent } from '../components/header/header.component';
import { FooterComponent } from '../components/footer/footer.component';
import { BodyComponent } from '../components/body/body.component';
import { SidebarComponent } from '../components/sidebar/sidebar.component';
import { BlogListComponent } from '../components/blog-list/blog-list.component';
import { BlogSummaryComponent } from '../components/blog-summary/blog-summary.component';
import { BlogDetailsComponent } from '../components/blog-details/blog-details.component';
import { AboutComponent } from '../components/about/about.component';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

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
    BrowserAnimationsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
