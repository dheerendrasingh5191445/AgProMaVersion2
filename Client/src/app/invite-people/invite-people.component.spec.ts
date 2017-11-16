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
import { InvitePeopleService } from '../shared/services/invite-people.service';
import { LoginService } from '../shared/services/login.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { InvitePeopleComponent } from './invite-people.component';
describe('InvitePeopleComponent', () => {
  let component: InvitePeopleComponent;
  let loginservice: LoginService;
  let invitePeople: InvitePeopleService;
  let route: Router;
  let spyinviteMember: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<InvitePeopleComponent>;
  const mockResponse = "Already Exist";                        //Response being mocked for testing
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [InvitePeopleComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [InvitePeopleService, LoginService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(InvitePeopleComponent);
    component = fixture.componentInstance;
    // loginservice = fixture.debugElement.injector.get(LoginService); //injecting real service
    invitePeople = fixture.debugElement.injector.get(InvitePeopleService); //injecting real service 
    spyinviteMember = spyOn(invitePeople, 'emailto') //spying on checklist service on addchecklist method
      .and.returnValue(Promise.resolve(mockResponse));
  });
  it('can instantiate service when inject service', //first test case
    inject([InvitePeopleService], (service: InvitePeopleService) => {
      expect(service instanceof InvitePeopleService).toBe(true);
    }));
  it('can instantiate service with "new"', inject([Http], (http: Http) => { //second test case
    expect(http).not.toBeNull('http should be provided');
    let service = new InvitePeopleService(http, route);
    expect(service instanceof InvitePeopleService).toBe(true, 'new service should be ok');
  }));
  it('can provide the mockBackend as XHRBackend', //third test case
    inject([XHRBackend], (backend: MockBackend) => {
      expect(backend).not.toBeNull('backend should be provided');
    }));
});