import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarPostComponent } from './agregar-post.component';

describe('AgregarPostComponent', () => {
  let component: AgregarPostComponent;
  let fixture: ComponentFixture<AgregarPostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarPostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
