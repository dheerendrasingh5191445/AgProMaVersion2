using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgpromaWebAPI.model;
using AgpromaWebAPI.Repository;
using AgpromaWebAPI.Viewmodel;

namespace AgpromaWebAPI.Service
{
    public interface ICheckListService
    {
        TaskBacklog GetTaskDetail(int Id);
        List<ChecklistBacklog> Get();
        List<ChecklistBacklog> Get(int id);
        void Add_Checklist(ChecklistBacklog addChecklist);
        void Delete(int id);
        void Update_DailyStatus(CheckList checklist);

    }
    public class ChecklistService : ICheckListService
    {
        private ICheckListRepository _context; //repository instance
        public ChecklistService(ICheckListRepository con)
        {
            _context = con;
       
        }
        //add checklist
        public void Add_Checklist(ChecklistBacklog addChecklist)//for adding checklist
        {
            _context.Add_Checklist(addChecklist);
        }

        public void Delete(int id) //deleting checklist
        {
            _context.Delete(id);
        }

        public List<ChecklistBacklog> Get() //getting list
        {
            return _context.Get().ToList();
        }
        //get checklist corresponding to a task id
        public List<ChecklistBacklog> Get(int id)
        {
            return _context.Get(id);
        }

        public TaskBacklog GetTaskDetail(int Id)
        {
            return _context.GetTaskDetail(Id);
        }
        //update checklist remaining time
        public void Update_DailyStatus(CheckList checklist)
        {
            _context.Update_DailyStatus(checklist);
         
        }

    }
}
