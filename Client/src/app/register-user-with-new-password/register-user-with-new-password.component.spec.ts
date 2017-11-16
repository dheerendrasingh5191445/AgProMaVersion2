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
import { RegisterUserWithNewPasswordService } from '../shared/services/register-user-with-new-password.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { RegisterUserWithNewPasswordComponent } from './register-user-with-new-password.component';
describe('RegisterUserWithNewPasswordComponent', () => {
  let component: RegisterUserWithNewPasswordComponent;
  let registerUser: RegisterUserWithNewPasswordService;
  let route: Router;
  let spyresetPassword: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<RegisterUserWithNewPasswordComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [RegisterUserWithNewPasswordComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [RegisterUserWithNewPasswordService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterUserWithNewPasswordComponent);
    component = fixture.componentInstance;
    registerUser = fixture.debugElement.injector.get(RegisterUserWithNewPasswordService);  //injecting real service 
    spyresetPassword = spyOn(registerUser, 'updatePassword') //spying on checklist service on addchecklist method
      .and.returnValue(Observable.of("{status:200}"));
  });
  it('can instantiate service when inject service', //first test case
    inject([RegisterUserWithNewPasswordService], (service: RegisterUserWithNewPasswordService) => {
      expect(service instanceof RegisterUserWithNewPasswordService).toBe(true);
    }));
  it('can instantiate service with "new"', inject([Http], (http: Http) => { //second test case
    expect(http).not.toBeNull('http should be provided');
    let service = new RegisterUserWithNewPasswordService(http, route);
    expect(service instanceof RegisterUserWithNewPasswordService).toBe(true, 'new service should be ok');
  }));
  it('can provide the mockBackend as XHRBackend', //third test case
    inject([XHRBackend], (backend: MockBackend) => {
      expect(backend).not.toBeNull('backend should be provided');
    }));
});