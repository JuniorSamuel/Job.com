import { TestBed } from '@angular/core/testing';

import { AdmitGuard } from './admit.guard';

describe('AdmitGuard', () => {
  let guard: AdmitGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AdmitGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
