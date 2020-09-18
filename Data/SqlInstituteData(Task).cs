using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData
    {
        public void AddTask(Model.Task newtask)
        {
            throw new NotImplementedException();
        }

        public void AddTask<T>(T Target, Model.Task newtask)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Model.Task deleteTask)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.Task>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Model.Task> GetTaskById(int taskid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.Task>> GetTasks<T>(T Target)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Model.Task updatingtask)
        {
            throw new NotImplementedException();
        }
    }
}
