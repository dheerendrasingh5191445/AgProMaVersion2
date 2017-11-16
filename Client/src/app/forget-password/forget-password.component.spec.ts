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
import { ForgetServiceService } from '../shared/services/forget-service.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ForgetPasswordComponent } from './forget-password.component';
import swal from 'sweetalert2';
describe('ForgetPasswordComponent', () => {
  let component: ForgetPasswordComponent;
  let forget: ForgetServiceService;
  let route: Router;
  let spygenerateEmail: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<ForgetPasswordComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [ForgetPasswordComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [ForgetServiceService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(ForgetPasswordComponent);
    component = fixture.componentInstance;
    forget = fixture.debugElement.injector.get(ForgetServiceService);  //injecting real service 
    spygenerateEmail = spyOn(forget, 'emailto') //spying on checklist service on addchecklist method
      .and.returnValue(Observable.of("{status:200}"));
  });
  it('can instantiate service when inject service', //first test case
    inject([ForgetServiceService], (service: ForgetServiceService) => {
      expect(service instanceof ForgetServiceService).toBe(true);
    }));
  it('can instantiate service with "new"', inject([Http], (http: Http) => { //second test case
    expect(http).not.toBeNull('http should be provided');
    let service = new ForgetServiceService(http, route);
    expect(service instanceof ForgetServiceService).toBe(true, 'new service should be ok');
  }));
  it('can provide the mockBackend as XHRBackend', //third test case
    inject([XHRBackend], (backend: MockBackend) => {
      expect(backend).not.toBeNull('backend should be provided');
    }));
});