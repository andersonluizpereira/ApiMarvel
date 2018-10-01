import { RequestOptionsArgs, RequestOptions,Headers } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class DefaultRequestOptionsServiceService  extends RequestOptions  {

  constructor() {
    super();
  }

  merge(options?: RequestOptionsArgs): RequestOptions {
    let headers = options.headers || new Headers();
    headers.set('Content-Type', 'application/json');
    options.headers = headers;
    return super.merge(options);
}


}
