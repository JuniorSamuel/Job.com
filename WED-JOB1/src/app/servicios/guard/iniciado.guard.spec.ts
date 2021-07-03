import { TestBed } from '@angular/core/testing';

import { IniciadoGuard } from './iniciado.guard';

describe('IniciadoGuard', () => {
  let guard: IniciadoGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IniciadoGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
