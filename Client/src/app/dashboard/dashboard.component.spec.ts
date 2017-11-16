import { async, ComponentFixture, TestBed, fakeAsync, tick, inject } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthService } from 'angular4-social-login';
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
import { LoginService } from '../shared/services/login.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
class RouterStub {
  navigate(url: string) { return url; }
}
describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let loginservice: LoginService;
  let route: Router;
  let spyonLoggedout: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<DashboardComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [DashboardComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [LoginService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    loginservice = fixture.debugElement.injector.get(LoginService);  //injecting real service 
    //  authService = fixture.debugElement.injector.get(AuthService);
    spyonLoggedout = spyOn(loginservice, 'logOut') //spying on checklist service on onstart method
      .and.returnValue(Promise.resolve(""));
  });
});