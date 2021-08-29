import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html'
})
export class NewAccountComponent implements OnInit {

  public firstName = "";
  public lastName = "";
  public balance = "";


  constructor(private http: HttpClient, private route: Router) {
  }

  private accountsUrl = "/api/accounts";

  saveAccount(){
    this.http.post<any>(this.accountsUrl,
      {
        FirstName: this.firstName,
        LastName: this.lastName,
        Balance: this.balance
      }).subscribe(data => {
        this.route.navigate(['/accounts']);
  });
}

  ngOnInit(): void {
  }

}
