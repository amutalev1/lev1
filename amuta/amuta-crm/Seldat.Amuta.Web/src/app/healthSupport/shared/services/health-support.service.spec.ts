import { TestBed } from '@angular/core/testing';

import { HealthSupportService } from './health-support.service';

describe('HealthSupportService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HealthSupportService = TestBed.get(HealthSupportService);
    expect(service).toBeTruthy();
  });
});
