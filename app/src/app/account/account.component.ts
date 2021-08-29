import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AccountGridDataModel } from './account-grid-data.model';
import { RouterModule, Routes } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html'
})
export class AccountComponent implements OnInit {

  /* TODO:
  - Load Accounts from the REST Api
  - Display Accounts in the HTML Table
  - Filter Accounts based on the Account Type
   */

  constructor(private http: HttpClient, router: RouterModule) {
  }

  accountTypeChanged(type: string) {
    if (!type) {
      this.accountsFiltered = this.accounts;
      return;
    }

    this.accountsFiltered = this.accounts.filter(x => x.accountType == type);
  }

  public accounts: AccountGridDataModel[] = [];
  public accountsFiltered: AccountGridDataModel[] = [];

  private accountsUrl = "/api/accounts";

  ngOnInit(): void {
    this.getAccounts().subscribe(data => {
      this.accounts = data;
      this.accountsFiltered = data;
    });
  }

  getAccounts(): Observable<AccountGridDataModel[]> {
    return this.http.get<AccountGridDataModel[]>(this.accountsUrl)
  }
}
