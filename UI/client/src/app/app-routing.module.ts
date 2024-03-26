import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './books/book-list/book-list.component';
import { AuthorListComponent } from './authors/author-list/author-list.component';
import { AuthorDetailComponent } from './authors/author-detail/author-detail.component';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { HomeComponent } from './home/home.component';
import { authGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '', 
  runGuardsAndResolvers: 'always',
  canActivate: [authGuard],
 children:[
  {path: 'authors', component: AuthorListComponent},
  {path: 'authors/:id', component: AuthorDetailComponent},
  {path: 'books', component: BookListComponent},
  {path: 'books/:id', component: BookDetailComponent},
 ]},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
