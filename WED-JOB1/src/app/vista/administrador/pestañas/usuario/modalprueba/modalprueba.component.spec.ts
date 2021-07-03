import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalpruebaComponent } from './modalprueba.component';

describe('ModalpruebaComponent', () => {
  let component: ModalpruebaComponent;
  let fixture: ComponentFixture<ModalpruebaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalpruebaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalpruebaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
