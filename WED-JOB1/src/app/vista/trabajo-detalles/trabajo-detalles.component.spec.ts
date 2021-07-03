import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrabajoDetallesComponent } from './trabajo-detalles.component';

describe('TrabajoDetallesComponent', () => {
  let component: TrabajoDetallesComponent;
  let fixture: ComponentFixture<TrabajoDetallesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrabajoDetallesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrabajoDetallesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
