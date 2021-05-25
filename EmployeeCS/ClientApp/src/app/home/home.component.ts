import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Employee } from "../models/Employee";
import { EmployeeShort } from "../models/EmployeeShort";
import { NavigationExtras, Router } from "@angular/router";
import { EmployeeRepository } from "../repositories/Employeerepository";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent {
  employees: EmployeeShort[];
  employeeDetail: Employee;
  isLoading: boolean = true;
  confirmation: boolean = false;
  edit: boolean = false;

  openCreate() {
    this.router.navigate(["/create"]);
  }

  openEdit() {
    this.router.navigate(["/" + this.employeeDetail.id + "/edit"]);
  }

  constructor(private repository: EmployeeRepository, private router: Router) {
    repository.getAllEmployees().subscribe(
      (result) => {
        this.employees = result;
        this.changeSelectedItem(this.employees[0].id);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  changeSelectedItem(id: number) {
    this.isLoading = true;
    this.repository.getEmployeeDetails(id).subscribe(
      (result) => {
        this.employeeDetail = result;
        this.isLoading = false;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteSelected() {
    this.confirmation = false;
    this.repository.deleteEmployee(this.employeeDetail.id).subscribe(
      () => {
        this.employees = this.employees.filter(
          (el) => el.id != this.employeeDetail.id
        );
        this.changeSelectedItem(this.employees[0].id);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  showConfirmation() {
    this.confirmation = true;
  }

  cancelDelete() {
    this.confirmation = false;
  }
}
