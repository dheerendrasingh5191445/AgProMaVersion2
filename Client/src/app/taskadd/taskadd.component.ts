import { Component, OnInit } from '@angular/core';
import { Task } from '../shared/model/task';
import swal from 'sweetalert2';
import { HubConnection } from '@aspnet/signalr-client';
import { ActivatedRoute } from '@angular/router';
import { ConfigFile } from './../shared/config';

@Component({
 selector: 'app-taskadd',
 templateUrl: './taskadd.component.html',
 styleUrls: ['./taskadd.component.css']
})
export class TaskAddComponent implements OnInit {
 //variable declaration

 sub: string = "";
 data: Task[]=[];
 connection: HubConnection;
 userId:number;
 owner:any="param kewale";
 storyId:number;
 status:number=0;
 startDate:Date=null;
 endDate:Date=null;
 constructor(private route:ActivatedRoute) {

 }
 //this will get the task backlog list
  ngOnInit() {
   this.route.params.subscribe((param) =>{ this.storyId = +param['id'];});
   this.connectToHub();
  }

 //this is to make connection with the hub
 connectToHub(){
   var session = sessionStorage.getItem("id");
   this.userId = parseInt(session);
   this.connection = new HubConnection(ConfigFile.TaskAddUrls.connection);//for connecting with hub // when this component reload ,it will call this method
   //registering event handlers
   this.connection.on("gettask",data=>{this.data = data;});//this will return task backlogs
   this.connection.on("whenUpdated",data => { swal('Task Updated', '', 'success') }); //sweet alert when task happens
   this.connection.on("whenAdded",data => { swal('Task Added', '', 'success') });  
   this.connection.start().then(() => {
   this.connection.invoke("SetConnectionId",this.userId);
   this.connection.invoke("GetTaskBacklogs",this.storyId);
   });
 }

 //this will add new task to the backlog
 addBacklog(taskName: string, startDate: any, endDate: any,description:string,plannedSize:number) {
   //this will give alert if nothing is entered as task
   
  //  if ((taskName == "") || (plannedSize == null) || (startDate == null) || (endDate == null)) {
  //    swal('Do not leave white space in any block ', '', 'warning');
  //  }
   //to validate start date greater than enddate
   //this will work if task name is entered and  add new task to backlog
  //  console.log("Date======>"+this.startDate['formatted']);
  //  console.log(this.startDate['formatted'] < this.endDate['formatted']);
   
   if (taskName && this.startDate['formatted'] < this.endDate['formatted']) {
     
     let model = new Task(this.storyId,taskName,this.owner,this.status,startDate,endDate,description,plannedSize);
     model.startDate= this.startDate['formatted'];
     model.endDate=this.endDate['formatted'];
     console.log(model);
     this.connection.invoke("PostTask",model,this.storyId)
      this.connection.invoke("GetTaskBacklogs",this.storyId);
   }
   else{
     swal('startDate cannot be greater than enddate','', 'warning');
   }
 }

  //this will uddate task backlog values
 updateBacklog(taskId:number,content: any, startDate: any, endDate: any,description:any,plannedSize:any) {
   //this will give alert if no task is entered for updation(empty value)
   console.log(plannedSize);
   if ((content.replace(/ /g , "") == "")) {
     swal('Enter Some Task', '', 'warning')
   }
   if(content && this.startDate['formatted'] < this.endDate['formatted']) {
     let model=new Task(taskId,content,this.owner,this.status,startDate,endDate,description,plannedSize);
     model.title = content;
     model.description=description;
 
     //this will give alert if task is successfully upadated
     this.connection.invoke("UpdateTask",taskId,model);
   }
   else{
     swal('startDate cannot be greater than enddate','', 'warning');
   }
 }
 
}