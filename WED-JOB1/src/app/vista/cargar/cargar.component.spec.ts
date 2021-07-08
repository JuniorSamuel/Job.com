import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargarComponent } from './cargar.component';

describe('CargarComponent', () => {
  let component: CargarComponent;
  let fixture: ComponentFixture<CargarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CargarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CargarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
