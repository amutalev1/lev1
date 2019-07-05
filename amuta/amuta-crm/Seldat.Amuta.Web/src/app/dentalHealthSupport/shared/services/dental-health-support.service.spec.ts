import { TestBed } from '@angular/core/testing';

import { DentalHealthSupportService } from './dental-health-support.service';

describe('DentalHealthSupportService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DentalHealthSupportService = TestBed.get(DentalHealthSupportService);
    expect(service).toBeTruthy();
  });
});
