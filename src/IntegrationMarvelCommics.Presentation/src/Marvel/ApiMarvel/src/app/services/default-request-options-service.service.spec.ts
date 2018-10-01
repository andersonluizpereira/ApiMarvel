import { TestBed, inject } from '@angular/core/testing';

import { DefaultRequestOptionsServiceService } from './default-request-options-service.service';

describe('DefaultRequestOptionsServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DefaultRequestOptionsServiceService]
    });
  });

  it('should be created', inject([DefaultRequestOptionsServiceService], (service: DefaultRequestOptionsServiceService) => {
    expect(service).toBeTruthy();
  }));
});
