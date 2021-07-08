import { TestBed } from '@angular/core/testing';

import { JwtInteceptorInterceptor } from './jwt-inteceptor.interceptor';

describe('JwtInteceptorInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      JwtInteceptorInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: JwtInteceptorInterceptor = TestBed.inject(JwtInteceptorInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
