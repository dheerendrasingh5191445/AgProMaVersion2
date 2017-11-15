using AgpromaWebAPI.model;
using AgpromaWebAPI.Repository;
using AgpromaWebAPI.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgpromaWebAPI.Service
{
    public interface ITaskBacklogService
    {
        List<TaskBacklog> GetAllTask(int storyId);
        List<TeamMaster> GetTeamByProjectId(int storyId);
        List<AvailTeamMember> getTeamMember(int teamId);
        void UpdateTask(int memberID, int taskId);
        void UpdateConnectionId(string connectionid, int memberid);
        List<AvailableMember> GetTeamMemberNames(int storyId);
        int GetProjectId(int StoryId);
    }
    public class TaskBacklogService : ITaskBacklogService
    {
        ITaskBacklogReposiory _taskBacklog;
        public TaskBacklogService(ITaskBacklogReposiory taskBacklog)
        {
            _taskBacklog = taskBacklog;
        }

        public List<TeamMaster> GetTeamByProjectId(int storyId)
        {
            return _taskBacklog.getAllTeams(storyId);
        }

        public List<AvailableMember> GetTeamMemberNames(int storyId)
        {
            List<AvailableMember> availteam = new List<AvailableMember>();
            int projectId = _taskBacklog.GetProjectId(storyId);
            List<Projectmembers> projectmem = _taskBacklog.AllMember(projectId);
            foreach (Projectmembers pro in projectmem)
            {
                User master = _taskBacklog.Master(pro.MemberId);
                AvailableMember avail = new AvailableMember();
                avail.MemberId = master.Id;
                avail.MemberName = master.FirstName + ' ' + master.LastName;
                availteam.Add(avail);
            }
            return availteam;

        }

        public List<AvailTeamMember> getTeamMember(int teamId)
        {
            List<AvailTeamMember> availteam = new List<AvailTeamMember>();
            List<TeamMember> teammas = _taskBacklog.AllTeamMember();
            foreach (TeamMember tm in teammas)
            {
                if (tm.TeamId == teamId)
                {
                    User master = _taskBacklog.Master(tm.MemberId);
                    AvailTeamMember avail = new AvailTeamMember();
                    avail.MemberId = master.Id;
                    avail.MemberName = master.FirstName + ' ' + master.LastName;
                    avail.TeamId = tm.TeamId;
                    avail.Id = tm.Id;
                    availteam.Add(avail);
                }
            }
            return availteam;
        }

        public void UpdateTask(int memberID, int taskId)
        {
            _taskBacklog.Update(memberID, taskId);
        }

        //this method will return all the task in that same sprint
        public List<TaskBacklog> GetAllTask(int storyId)
        {
            //List<TaskBacklogView> taskblv = new List<TaskBacklogView>();
            //List<TaskBacklog> taskbacklog = _taskBacklog.GetAllTaskDetail(id);
            //foreach (TaskBacklog tb in taskbacklog)
            //{
            //    TaskBacklogView tblv = new TaskBacklogView();
            //    tblv.TaskId = tb.TaskId;
            //    tblv.TaskName = tb.n;
            //    tblv.PersonId = tb.PersonId;
            //    tblv.SprintId = tb.SprintId;
            //    tblv.StartDate = tb.StartDate;
            //    tblv.ActualEndDate = tb.ActualEndDate;
            //    tblv.EndDate = tb.EndDate;
            //    tblv.Status = tb.Status;
            //    taskblv.Add(tblv);
            //}
            //return taskblv;

            return _taskBacklog.GetAllTaskDetail(storyId);
        }

        public void UpdateConnectionId(string connectionid, int memberid)
        {
            _taskBacklog.UpdateConnectionId(connectionid, memberid);
        }

        public int GetProjectId(int StoryId)
        {
            return _taskBacklog.GetProjectId(StoryId);
        }
    }
}
