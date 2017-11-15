using AgpromaWebAPI.model;
using AgpromaWebAPI.Repository;
using AgpromaWebAPI.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgpromaWebAPI.Service
{
    public interface ITaskServices
    {
        List<SignalRMaster> JoinGroup(int projectId);
        void SetConnectionId(string connectionId, int memberId);
        List<TaskBacklog> GetAll(int storyId);
        string Add(TaskBacklog backlog);
        void Update(int id, TaskBacklog res);
        int GetProjectId(int storyId);
        void Update_RemainingTime(ChecklistBacklog checklist);
    }

    public class TaskService : ITaskServices
    {
        private ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public string Add(TaskBacklog backlog)
        {
            int plannedsize = _repository.GetStoryPlannedSize(backlog.StoryId);
            int sum = 0;
            sum = AveragePlanSize(backlog.StoryId);
            sum += backlog.PlannedSize;
            if (sum <= plannedsize)
            {
                _repository.Add(backlog);
                return "matched";
            }
            else
            {
                return "unmatched";
            }

        }

        public List<TaskBacklog> GetAll(int storyId)
        {
            //List<TackBacklogView> taskblv=new List<TaskBacklogView>();
            List<TaskBacklog> taskbacklog = _repository.GetAll(storyId);
            return taskbacklog;
        }

        public void Update(int id, TaskBacklog res)
        {
            _repository.Update(id, res);

        }

        public void SetConnectionId(string connectionId, int memberId)
        {
            _repository.SetConnectionId(connectionId, memberId);
        }

        public List<SignalRMaster> JoinGroup(int projectId)
        {
            return _repository.JoinGroup(projectId);
        }

        public int GetProjectId(int storyId)
        {
            int sp = _repository.GetProjectId(storyId);
            return sp;//TASK TO DO
        }
        public int AveragePlanSize(int userStoryId)
        {
            List<TaskBacklog> bck = _repository.GetAll(userStoryId);
            int sum = 0;
            foreach (TaskBacklog tb in bck)
            {
                sum = sum + tb.PlannedSize;
            }

            return sum;
        }


        public void Update_RemainingTime(ChecklistBacklog checklist)
        {
            _repository.Update_RemainingTime(checklist);
        }
    }
}