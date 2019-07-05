import { TestBed } from '@angular/core/testing';

import { FinancialSupportService } from './financial-support.service';

describe('FinancialSupportService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FinancialSupportService = TestBed.get(FinancialSupportService);
    expect(service).toBeTruthy();
  });
});
