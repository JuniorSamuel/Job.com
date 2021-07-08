import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarcategoriaComponent } from './agregarcategoria.component';

describe('AgregarcategoriaComponent', () => {
  let component: AgregarcategoriaComponent;
  let fixture: ComponentFixture<AgregarcategoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarcategoriaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarcategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
