import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountTypeModel } from './account-type.model';

@Component({
  selector: 'app-account-type',
  templateUrl: './account-type.component.html'
})
export class AccountTypeComponent implements OnInit {
  @Output() filterChanged: EventEmitter<string> = new EventEmitter<string>();

  constructor(private http: HttpClient) {
  }
  accountType: string;
  public accountTypes: string[] = [];

  ngOnInit(): void {
    this.getAccountTypes().subscribe(data => this.accountTypes = data);
  }

  accountTypeChanged() {
    this.filterChanged.emit(this.accountType);
  }

  getAccountTypes(): Observable<string[]> {
    return this.http.get<string[]>("/api/accounttypes")
  }

}
