import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MisPostComponent } from './mis-post.component';

describe('MisPostComponent', () => {
  let component: MisPostComponent;
  let fixture: ComponentFixture<MisPostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ MisPostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MisPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});
