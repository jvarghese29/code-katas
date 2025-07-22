using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ProjectKanban.Controllers;
using ProjectKanban.Users;
using ProjectKanban.Utilities;

namespace ProjectKanban.Tasks
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;
        private readonly UserRepository _userRepository;

        public TaskService(TaskRepository taskRepository, UserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public TaskModel GetById(Session session, int id)
        {
            var taskRecord = _taskRepository.GetById(id);
            return new TaskModel
            {
                Description = taskRecord.Description,
                Status = taskRecord.Status,
                EstimatedDevDays = taskRecord.EstimatedDevDays,
                Id = taskRecord.Id,
                AssignedUsers = GetAssignedUsersByTaskId(id)
            };
        }

        public GetAllTasksResponse GetAll(Session session)
        {
            var currentUser = _userRepository.GetByUsername(session.Username);

            var taskModels = _taskRepository.GetAll()
                .Where(task => task.ClientId == currentUser.ClientId)
                .Select(task => new TaskModel
                {
                    Id = task.Id,
                    Status = task.Status,
                    EstimatedDevDays = task.EstimatedDevDays,
                    Description = task.Description,
                    AssignedUsers = GetAssignedUsersByTaskId(task.Id)
                })
                .OrderBy(task => Helper.GetStatusRank(task.Status))
                .ToList();

            return new GetAllTasksResponse { Tasks = taskModels };
        }


        public List<TaskAssignedUserModel>  GetAssignedUsersByTaskId(int id)
        {
             var assignedUsers = new List<TaskAssignedUserModel>();
            var assigned = _taskRepository.GetAssignedFor(id);
            foreach (var assignee in assigned)
            {
                var user = _userRepository.GetAll().First(x => x.Id == assignee.UserId);
                assignedUsers.Add(new TaskAssignedUserModel { Username = user.Username });
            }

            return assignedUsers;
        }

       
    }
}