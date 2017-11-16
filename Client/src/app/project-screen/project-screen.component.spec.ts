import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectScreenComponent } from './project-screen.component';

describe('ProjectScreenComponent', () => {
  let component: ProjectScreenComponent;
  let fixture: ComponentFixture<ProjectScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});
