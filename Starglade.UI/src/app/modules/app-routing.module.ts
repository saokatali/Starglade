import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlogListComponent } from '../components/blog-list/blog-list.component';

import { AboutComponent } from '../components/about/about.component';


const routes: Routes = [
  {path: 'blog-list', component: BlogListComponent},
  {path: '',  pathMatch: 'full', redirectTo: 'blog-list'},
  {path: 'about', component: AboutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
