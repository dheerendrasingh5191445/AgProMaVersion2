//import all dependency
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
import { ActivatedRoute, ParamMap } from '@angular/router';
import { BacklogComponent } from './backlog.component';
describe('BacklogComponent', () => {
  let component: BacklogComponent;
  
  let route:Router;
  let spyconnectBacklogHub: jasmine.Spy;
  let spyaddBacklog: jasmine.Spy;
  let spyupdateBacklog: jasmine.Spy;
  let spydeleteBacklog:jasmine.Spy;
  let de: DebugElement;
  let el: HTMLElement;
  let fixture: ComponentFixture<BacklogComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpModule, FormsModule, NgxPaginationModule, //modules imported
        RouterTestingModule],
        declarations: [ BacklogComponent ],    //declaring modules being imported
      schemas: [NO_ERRORS_SCHEMA],           //declaring schemas
      providers: [] //provider for real service
    })
    .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(BacklogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  it('Product backlog heading', async(() => { //first test case
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      fixture.detectChanges();
      de = fixture.debugElement.query(By.css("h4"));
      el = de.nativeElement;
      expect(el.textContent).toEqual("Product Backlog");
    });
  }));
    it('Details heading of Product backlog ', async(() => { //second test case
      fixture.detectChanges();
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        de = fixture.debugElement.query(By.css("h5"));
        el = de.nativeElement;
        expect(el.textContent).toEqual(" Add New");
      });
  }));
it('size details ', async(() => { //fourth test case
  fixture.detectChanges();
  fixture.whenStable().then(() => {
    fixture.detectChanges();
    de = fixture.debugElement.query(By.css("#plannedSize"));
    el = de.nativeElement;
    expect(el.textContent).toEqual("Planned Size :");
  });
}));
it('Actual Size details ', async(() => { //fifth test case
  fixture.detectChanges();
  fixture.whenStable().then(() => {
    fixture.detectChanges();
    de = fixture.debugElement.query(By.css("#actualSize"));
    el = de.nativeElement;
    expect(el.textContent).toEqual("Actual Size :");
  });
}));
it('Priority details ', async(() => { //sixth test case
  fixture.detectChanges();
  fixture.whenStable().then(() => {
    fixture.detectChanges();
    de = fixture.debugElement.query(By.css("#priority"));
    el = de.nativeElement;
    expect(el.textContent).toEqual("Priority No. :");
  });
}));
it('Comment details ', async(() => { //sixth test case
  fixture.detectChanges();
  fixture.whenStable().then(() => {
    fixture.detectChanges();
    de = fixture.debugElement.query(By.css("#comment"));
    el = de.nativeElement;
    expect(el.textContent).toEqual("Comment :");
  });
}));
it('Delete method call', async(() => { //seventh test case
  fixture.detectChanges();
  fixture.whenStable().then(() => {
    fixture.detectChanges();
    de = fixture.debugElement.query(By.css("#deleteBacklog"));
    el = de.nativeElement;
    el.click();
    expect(component.deleteBacklog).toEqual(true);
  });
}));
it('updateBacklog method call', async(() => { //eigth test case
  fixture.detectChanges();
  fixture.whenStable().then(() => {
    fixture.detectChanges();
    de = fixture.debugElement.query(By.css("#updateBacklog"));
    el = de.nativeElement;
    el.click();
    expect(component.updateBacklog).toEqual(true);
  });
}));
});