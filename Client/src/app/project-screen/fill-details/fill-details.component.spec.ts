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
import { FillDetailsComponent } from './fill-details.component';
class RouterStub {
  navigate(url: string) { return url; }
}
describe('FillDetailsComponent', () => {
  let component: FillDetailsComponent;
  let projectscrservice: ProjectScreenService;
  let route: Router;
  let spybackOnPrevious: jasmine.Spy;
  let spyAddProject: jasmine.Spy;
  let spyupdateProject: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<FillDetailsComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [FillDetailsComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [ProjectScreenService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(FillDetailsComponent);
    component = fixture.componentInstance;
    projectscrservice = fixture.debugElement.injector.get(ProjectScreenService);  //injecting real service 
    spyAddProject = spyOn(projectscrservice, 'addNewProject') //spying on checklist service on onstart method
      .and.returnValue(Promise.resolve(""));
    spyupdateProject = spyOn(projectscrservice, 'updateProject') //spying on checklist service on onstart1 method
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
  it('AddProject', async(() => { //fourth test case
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      component.AddProject();
      fixture.detectChanges();
      spyOn(window, "alert");
      fixture.detectChanges();
      expect(spyAddProject.calls.any()).toEqual(false);
      fixture.detectChanges();
    });
  }));
  it('updateProject', async(() => { //fourth test case
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      component.updateProject();
      fixture.detectChanges();
      spyOn(window, "alert");
      fixture.detectChanges();
      expect(spyupdateProject.calls.any()).toEqual(false);
      fixture.detectChanges();
    });
  }));
});