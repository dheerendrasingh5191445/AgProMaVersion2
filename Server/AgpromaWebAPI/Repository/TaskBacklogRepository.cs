using Microsoft.EntityFrameworkCore;
using AgpromaWebAPI.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgpromaWebAPI.Viewmodel;

namespace AgpromaWebAPI.Repository
{
    public interface ITaskBacklogReposiory
    {
        //
        List<TaskBacklog> getByTaskId();
        //get all team details
        List<TeamMaster> getAllTeams(int storyId);
        //get all user stories
        List<TeamMember> AllTeamMember();
        void UpdateConnectionId(string connectionid, int memberid);
        List<TaskBacklog> GetAllTaskDetail(int StoryId);
        void Update(int memberId, int TaskId);
        List<Projectmembers> AllMember(int projectId);
        int GetProjectId(int StoryId);
        User Master(int userId);

       // List<AvailableMember> GetTeamMemberNames(int storyId);
    }
    public class TaskBacklogRepository : ITaskBacklogReposiory
    {
        private AgpromaDbContext _context;
        public TaskBacklogRepository(AgpromaDbContext context)
        {
            _context = context;
        }

        public List<TeamMember> AllTeamMember()
        {
            return _context.Teammembers.ToList();
        }

        public List<TaskBacklog> getByTaskId()
        {
            return _context.Tasks.ToList();

        }
        public List<TeamMaster> getAllTeams(int storyId)
        {
            return _context.Teams.Where(t=>t.ProjectId == _context.Userstories.Where(u=>u.StoryId==storyId).Select(u=>u.ProjectId).SingleOrDefault()).ToList();
        }

        public void Update(int memberId, int TaskId)
        {
            TaskBacklog task = _context.Tasks.FirstOrDefault(p => p.TaskId == TaskId);
            task.UserId = memberId;
            task.Status = TaskBacklogStatus.Inprogress;
            _context.SaveChanges();
        }

        //this method will return all the task in that same sprint from database
        public List<TaskBacklog> GetAllTaskDetail(int StoryId)
        {
            return _context.Tasks.Where(p => p.StoryId == StoryId).ToList();
        }

        public void UpdateConnectionId(string connectionid, int memberid)
        {
            SignalRMaster signalr = _context.SignalRDb.FirstOrDefault(m => m.MemberId == memberid);
            signalr.ConnectionId = connectionid;
            signalr.HubCode = HubCode.taskbl;
            _context.SaveChanges();
        }

        public List<Projectmembers> AllMember(int projectId)
        {
            return _context.Projectmembers.Where(p => p.ProjectId == projectId).ToList();
        }

        public int GetProjectId(int StoryId)
        {
            UserStory userStory = _context.Userstories.FirstOrDefault(p => p.StoryId == StoryId);
            return userStory.ProjectId;
        }

        public User Master(int userId)
        {
            return _context.Users.FirstOrDefault(p => p.Id == userId);
        }

        //public List<AvailableMember> GetTeamMemberNames(int storyId)
        //{
        //    var projid = GetProjectId(storyId);
        //    var pmembers = _context.Projectmembers.Where(p => p.ProjectId == projid).Select(p=>p.MemberId).ToList();
        //    var users = _context.Users.Where(u => pmembers.Contains(u.Id)).ToList();

        //    //var data= _context.Users.Where(u=>u.
        //}
    }
}