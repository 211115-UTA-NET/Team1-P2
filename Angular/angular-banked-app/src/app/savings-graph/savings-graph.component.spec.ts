import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavingsGraphComponent } from './savings-graph.component';

describe('SavingsGraphComponent', () => {
  let component: SavingsGraphComponent;
  let fixture: ComponentFixture<SavingsGraphComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SavingsGraphComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SavingsGraphComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
