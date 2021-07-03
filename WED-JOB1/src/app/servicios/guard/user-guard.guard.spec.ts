import { TestBed } from '@angular/core/testing';

import { UserGuardGuard } from './user-guard.guard';

describe('UserGuardGuard', () => {
  let guard: UserGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(UserGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
