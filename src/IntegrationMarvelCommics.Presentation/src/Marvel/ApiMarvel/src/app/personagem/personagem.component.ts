import { Component, OnInit } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import { DefaultRequestOptionsServiceService } from '../services/default-request-options-service.service';
import { Marvel } from './marvel';


@Component({
  selector: 'app-personagem',
  templateUrl: './personagem.component.html',
  styleUrls: ['./personagem.component.css']
})
export class PersonagemComponent implements OnInit {

  personagens: Marvel[];
  constructor(private http: Http,
              private requestOptions: DefaultRequestOptionsServiceService
  ) { }

  ngOnInit() {
    this.getPersonagens();
  }

  getPersonagens() {
    let requestOptions = new RequestOptions();
    requestOptions.headers = new Headers();
    requestOptions.headers.set('Content-Type', 'application/json');
    this.http.get('http://localhost:7767/api/Personagem/Hulk', requestOptions)
    .toPromise()
    .then(response =>
    this.personagens = response.json() || {}
    ).catch(
      this.personagens = null
    );

  }

}
