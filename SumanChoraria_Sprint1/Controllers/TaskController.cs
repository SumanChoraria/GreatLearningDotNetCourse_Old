using SumanChoraria_Sprint1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumanChoraria_Sprint1.Controllers
{
   
    public class TaskController: BaseController<TaskModel>
    {
        private readonly Context _context;

     
        public TaskController (Context context):base(context)
        {
            _context = context;

            if(_context.Tasks.Count() == 0)
            {
                _context.Tasks.Add(new TaskModel
                {
                    ProjectId=1,
                    Status=2,
                    AssignedToUserId=1,
                    Detail = "This is a test task",
                    CreatedOn = DateTime.Now
                });

                _context.Tasks.Add(new TaskModel
                {
                    ProjectId = 1,
                    Status = 3,
                    AssignedToUserId = 2,
                    Detail = "This is a test task",
                    CreatedOn = DateTime.Now
                });

                _context.Tasks.Add(new TaskModel
                {
                    ProjectId = 2,
                    Status = 4,
                    AssignedToUserId = 2,
                    Detail = "This is a test task",
                    CreatedOn = DateTime.Now
                });

                _context.SaveChanges();
            }
        }
    }
}
