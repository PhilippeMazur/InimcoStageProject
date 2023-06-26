import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangePersonComponent } from './change-person.component';

describe('ChangePersonComponent', () => {
  let component: ChangePersonComponent;
  let fixture: ComponentFixture<ChangePersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangePersonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangePersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
