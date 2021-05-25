import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Employee } from "../models/Employee";
import { EmployeeShort } from "../models/EmployeeShort";
import { NewEmployee } from "../models/NewEmployee";

export class EmployeeRepository {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getAllEmployees() {
    return this.http.get<EmployeeShort[]>(this.baseUrl + "api/employees");
  }

  getEmployeeDetails(id: number) {
    return this.http.get<Employee>(this.baseUrl + "api/employees/" + id);
  }

  deleteEmployee(id: number) {
    return this.http.delete(this.baseUrl + "api/employees/" + id);
  }

  updateEmployee(employee: Employee) {
    return this.http.put<Employee>(this.baseUrl + "api/employees/", employee);
  }

  createEmployee(employee: NewEmployee){
    return this.http.post<Employee>(this.baseUrl + "api/employees/", employee);
  }
}
