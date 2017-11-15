import { Sprint } from "./sprint";

export class TaskBackLog{    
    constructor(public TaskId: number,public title : number,public Description : string,
              public StartDate : Date,public EndDate : Date,public sprintBacklogs? : Sprint,
               public plannedSize?:number,public actualSize?:number,public actualEnddate?:Date,
               public remaining?:number,public status?:number,public userId?:number){}   
}
