import {async, ComponentFixture, TestBed, fakeAsync, tick, inject} from '@angular/core/testing';
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
import { KanbanService } from '../shared/services/kanban.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { KanbanBoardComponent } from './kanban-board.component';
describe('KanbanBoardComponent', () => {
  let component: KanbanBoardComponent;
  let kanbanService: KanbanService;
  let route:Router;
  let spyaddCheckList: jasmine.Spy;
  let spyonStartComponent: jasmine.Spy;
  let spydeleteChecklist: jasmine.Spy;
  let spymarkCompleted: jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<KanbanBoardComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({   //creates a module that overrides the actual dependencies with testing dependencies
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
      declarations: [KanbanBoardComponent],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [KanbanService] //providing the real service
    })
      .compileComponents()
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(KanbanBoardComponent);
    component = fixture.componentInstance;
    kanbanService = fixture.debugElement.injector.get(KanbanService);  //injecting real service 
  });
  it('can instantiate service when inject service', //first test case
    inject([KanbanService], (service: KanbanService) => {
      expect(service instanceof KanbanService).toBe(true);
    }));
  it('can instantiate service with "new"', inject([Http], (http: Http) => { //second test case
    expect(http).not.toBeNull('http should be provided');
    let service = new KanbanService(http);
    expect(service instanceof KanbanService).toBe(true, 'new service should be ok');
  }));
  it('can provide the mockBackend as XHRBackend', //third test case
    inject([XHRBackend], (backend: MockBackend) => {
      expect(backend).not.toBeNull('backend should be provided');
    }));
});