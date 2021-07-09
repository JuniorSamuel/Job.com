import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargarAdmitComponent } from './cargar-admit.component';

describe('CargarAdmitComponent', () => {
  let component: CargarAdmitComponent;
  let fixture: ComponentFixture<CargarAdmitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ CargarAdmitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CargarAdmitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});
