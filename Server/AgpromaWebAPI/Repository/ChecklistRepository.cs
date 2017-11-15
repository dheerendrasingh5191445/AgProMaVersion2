using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgpromaWebAPI.model;
using Microsoft.EntityFrameworkCore;
using AgpromaWebAPI.Viewmodel;

namespace AgpromaWebAPI.Repository
{
    public interface ICheckListRepository //interface
    {
        TaskBacklog GetTaskDetail(int Id);
        List<ChecklistBacklog> Get();
        List<ChecklistBacklog> Get(int id);
        void Add_Checklist(ChecklistBacklog addchecklist);
        void Delete(int id);
        void Update_DailyStatus(CheckList checklist);
    }
    public class ChecklistRepository : ICheckListRepository 
    {
        private AgpromaDbContext _context;
        public ChecklistRepository(AgpromaDbContext con) 
        {
            _context = con;

        }
        public void Add_Checklist(ChecklistBacklog addchecklist) //adding checklist
        {
            
            _context.Checklists.Add(addchecklist);
            _context.SaveChanges();
        }

        public void Delete(int id) //delete checklist
        {
            ChecklistBacklog f = _context.Checklists.FirstOrDefault(p => p.ChecklistId == id);
            _context.Checklists.Remove(f);
            _context.SaveChanges();
        }

        public List<ChecklistBacklog> Get() //getting checklist
        {
            return _context.Checklists.Include(m=>m.TaskBacklog).ToList();
        }

        public List<ChecklistBacklog> Get(int id) //getting checklist according to task
        {
            List<ChecklistBacklog> check = _context.Checklists.Where(Id => Id.TaskId == id).ToList();
            return check;
        }

        public TaskBacklog GetTaskDetail(int Id)
        {
            return _context.Tasks.FirstOrDefault(p => p.TaskId == Id);
        }


        public void Update_DailyStatus(CheckList checklist)
        {
            ChecklistBacklog updatechecklist = _context.Checklists.FirstOrDefault(m => m.ChecklistId == checklist.ChecklistId);
            updatechecklist.ChecklistName = checklist.ChecklistName;
            updatechecklist.RemainingSize = checklist.RemainingSize;
            updatechecklist.CompletedSize = checklist.CompletedSize;
            updatechecklist.Status = checklist.Status;
            updatechecklist.ActualSize = checklist.ActualSize;


            //to update all other related tables
            updateActual(checklist);
            _context.SaveChanges();
        }



        public void updateActual(CheckList checklist)
        {
           // var checklistt = _context.Checklists.Where(c => c.ChecklistId == checklist.ChecklistId).FirstOrDefault();
            //var diff1=che


            var task = _context.Tasks.Where(t => t.TaskId == checklist.TaskId).SingleOrDefault();
           // var diff = checklist.ActualSize - checklist.PlannedSize;
            task.ActualSize = task.ActualSize + checklist.calculateDiff;
            task.Remaining = task.ActualSize-task.Remaining;

            var storyid = _context.Tasks.Where(t => t.TaskId == task.TaskId).Select(t => t.StoryId).FirstOrDefault();
            var userstory = _context.Userstories.Where(u => u.StoryId == storyid).FirstOrDefault();
            userstory.ActualSize = userstory.ActualSize + checklist.calculateDiff;

            var sprintid = _context.Sprint_UserStory.Where(s => s.StoryId == storyid).Select(s => s.SprintId).FirstOrDefault();
            var sprint = _context.Sprints.Where(s => s.SprintId == sprintid).SingleOrDefault();
            sprint.ActualSize = sprint.ActualSize + checklist.calculateDiff;

            TaskBurnDown tb = new TaskBurnDown();
            tb.TaskId = task.TaskId;
            tb.CheckListId = checklist.ChecklistId;
            tb.PointCompleted = checklist.CompletedSize;
            tb.PointRemaining = checklist.RemainingSize;
            tb.UserId = userstory.UserId;
            tb.Date = DateTime.UtcNow;
            _context.TaskBurnDowns.Add(tb);


        }

    }
}
