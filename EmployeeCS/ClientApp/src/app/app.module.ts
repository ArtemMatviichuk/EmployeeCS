import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EmployeeRepository } from './repositories/Employeerepository';
import { CreateEmployeeComponent } from './create/create.component';
import { EditEmployeeComponent } from './edit/edit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateEmployeeComponent,
    EditEmployeeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "create", component: CreateEmployeeComponent, pathMatch: "full" },
      { path: ":id/edit", component: EditEmployeeComponent, pathMatch: "full" },
    ]),
  ],
  providers: [EmployeeRepository],
  bootstrap: [AppComponent],
})
export class AppModule {}
