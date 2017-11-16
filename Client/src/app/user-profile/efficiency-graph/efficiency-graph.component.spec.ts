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
import { EfficiencyGraphService } from '../../shared/services/efficiency-graph.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { EfficiencyGraphComponent } from './efficiency-graph.component';
describe('EfficiencyGraphComponent', () => {
  let component: EfficiencyGraphComponent;
  let efficiencyGraphService: EfficiencyGraphService;
  let route: Router;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<EfficiencyGraphComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [EfficiencyGraphComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [EfficiencyGraphService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(EfficiencyGraphComponent);
    component = fixture.componentInstance;
    efficiencyGraphService = fixture.debugElement.injector.get(EfficiencyGraphService);  //injecting real service 
  });
  it('can instantiate service when inject service', //first test case
    inject([EfficiencyGraphService], (service: EfficiencyGraphService) => {
      expect(service instanceof EfficiencyGraphService).toBe(true);
    }));
  it('can instantiate service with "new"', inject([Http], (http: Http) => { //second test case
    expect(http).not.toBeNull('http should be provided');
    let service = new EfficiencyGraphService(http);
    expect(service instanceof EfficiencyGraphService).toBe(true, 'new service should be ok');
  }));
  it('can provide the mockBackend as XHRBackend', //third test case
    inject([XHRBackend], (backend: MockBackend) => {
      expect(backend).not.toBeNull('backend should be provided');
    }));
});
