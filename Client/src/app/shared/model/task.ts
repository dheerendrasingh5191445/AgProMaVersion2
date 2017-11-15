export class Task{
    constructor(
        public storyId:number,
        public title: string ,
        public owner:string,
        public status:number,
        public startDate:Date,
        public endDate:Date,
        public description:string,
        public plannedSize:number,
        ){}}