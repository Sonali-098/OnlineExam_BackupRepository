import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleReportAdminComponent } from './single-report-admin.component';

describe('SingleReportAdminComponent', () => {
  let component: SingleReportAdminComponent;
  let fixture: ComponentFixture<SingleReportAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingleReportAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleReportAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
