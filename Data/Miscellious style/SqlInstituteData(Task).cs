using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData
    {
        public void AddTask(Model.Assignment newtask)
        {
            throw new NotImplementedException();
        }

        public void AddTask<T>(T Target, Model.Assignment newtask)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Model.Assignment deleteTask)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.Assignment>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Model.Assignment> GetTaskById(int taskid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.Assignment>> GetTasks<T>(T Target)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Model.Assignment updatingtask)
        {
            throw new NotImplementedException();
        }
    }
}
