import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { Employee } from "../models/Employee";
import { NewEmployee } from "../models/NewEmployee";
import { EmployeeRepository } from "../repositories/Employeerepository";

@Component({
  selector: "app-create",
  templateUrl: "./create.component.html",
  styleUrls: ["./create.component.css"],
})
export class CreateEmployeeComponent {
  createForm = new FormGroup({
    firstName: new FormControl("", [
      Validators.required,
      Validators.minLength(3),
    ]),
    lastName: new FormControl("", [
      Validators.required,
      Validators.minLength(3),
    ]),
    gender: new FormControl(0),
    city: new FormControl("", [Validators.required, Validators.minLength(2)]),
  });

  constructor(private repository: EmployeeRepository, private router: Router) {}

  createEmployee(event) {
    let empl: NewEmployee = {
      firstName: this.createForm.controls["firstName"].value,
      lastName: this.createForm.controls["lastName"].value,
      gender: this.createForm.controls["gender"].value == 0,
      city: this.createForm.controls["city"].value,
    };
    this.repository.createEmployee(empl).subscribe(
      (result) => {
        this.router.navigate(["/"]);
      },
      (err) => {
        console.error(err);
      }
    );
  }

  cancelCreate(){
      this.router.navigate(["/"]);
  }

  get firstName() {
    return this.createForm.get("firstName");
  }

  get lastName() {
    return this.createForm.get("lastName");
  }

  get city() {
    return this.createForm.get("city");
  }
}
