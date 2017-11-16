import { async, ComponentFixture, TestBed, fakeAsync, tick, inject } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/Observable/of';
import { NgxPaginationModule } from 'ngx-pagination';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { HttpModule, Http, Response, ResponseOptions, XHRBackend } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MockBackend } from '@angular/http/testing';
import { ProjectScreenService } from '../../shared/services/project-screen.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ProjectDetailComponent } from './project-detail.component';
import { ProjectMaster } from './../../shared/model/ProjectMaster';
describe('ProjectDetailComponent', () => {
  let component: ProjectDetailComponent;
  let projectservice: ProjectScreenService;
  let route: Router;
  let spydelete: jasmine.Spy;
  let spyenterProject: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let router: Router;
  let fixture: ComponentFixture<ProjectDetailComponent>;
  let mockRouter = {
    navigate: jasmine.createSpy('navigate')
  }
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [ProjectDetailComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [ProjectScreenService, { provide: Router, useValue: mockRouter }] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectDetailComponent);
    component = fixture.componentInstance;
    component.Data = new Array<ProjectMaster>();
    projectservice = fixture.debugElement.injector.get(ProjectScreenService);  //injecting real service 
    spydelete = spyOn(projectservice, 'deleteProject') //spying on checklist service on addchecklist method
      .and.returnValue(Promise.resolve(""));
  });
  it('can instantiate service when inject service', //first test case
    inject([ProjectScreenService], (service: ProjectScreenService) => {
      expect(service instanceof ProjectScreenService).toBe(true);
    }));
  it('can instantiate service with "new"', inject([Http], (http: Http) => { //second test case
    expect(http).not.toBeNull('http should be provided');
    let service = new ProjectScreenService(http);
    expect(service instanceof ProjectScreenService).toBe(true, 'new service should be ok');
  }));
  it('can provide the mockBackend as XHRBackend', //third test case
    inject([XHRBackend], (backend: MockBackend) => {
      expect(backend).not.toBeNull('backend should be provided');
    }));
  it('enterProject', async(() => { //fourth test case
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      component.enterProject();
      fixture.detectChanges();
      expect(mockRouter.navigate).toHaveBeenCalledWith(['role-dashboard', undefined, 'kanban', undefined]);
    });
  }));
  it('delete', async(() => { //fourth test case
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      component.delete(1);
      fixture.detectChanges();
      fixture.detectChanges();
      expect(spydelete.calls.any()).toEqual(false);
      fixture.detectChanges();
    });
  }));
});