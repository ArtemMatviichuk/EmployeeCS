import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, NavigationExtras, Router } from "@angular/router";
import { Employee } from "../models/Employee";
import { EmployeeRepository } from "../repositories/Employeerepository";

@Component({
  selector: "app-edit",
  templateUrl: "./edit.component.html",
  styleUrls: ["./edit.component.css"],
})
export class EditEmployeeComponent {
  employeeId: number;

  editForm = new FormGroup({
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

  constructor(
    private repository: EmployeeRepository,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.employeeId = this.route.snapshot.params["id"];

    this.repository.getEmployeeDetails(this.employeeId).subscribe(
      (result) => {
        this.editForm.controls["firstName"].setValue(result.firstName);
        this.editForm.controls["lastName"].setValue(result.lastName);
        this.editForm.controls["gender"].setValue(
          result.gender === "Male" ? 0 : 1
        );
        this.editForm.controls["city"].setValue(result.city);
      },
      (err) => {
        console.log(err);
      }
    );
  }

  cancelEdit() {
    this.router.navigate(["/"]);
  }

  editSelected(event) {
    let empl: Employee = {
      id: this.employeeId,
      firstName: this.editForm.controls["firstName"].value,
      lastName: this.editForm.controls["lastName"].value,
      gender: this.editForm.controls["gender"].value == 0 ? "Male" : "Female",
      city: this.editForm.controls["city"].value,
    };
    this.repository.updateEmployee(empl).subscribe(
      (result) => {
        this.router.navigate(["/"]);
      },
      (err) => {
        console.error(err);
      }
    );
  }

  get firstName() {
    return this.editForm.get("firstName");
  }

  get lastName() {
    return this.editForm.get("lastName");
  }

  get city() {
    return this.editForm.get("city");
  }
}
