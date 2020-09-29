using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData
    {
        public void AddTest(Test newtest)
        {
            throw new NotImplementedException();
        }

        public void AddTest<T>(T Target, Test newtask)
        {
            throw new NotImplementedException();
        }

        public void DeleteTest(Model.Assignment deleteTest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Test>> GetAllTests()
        {
            throw new NotImplementedException();
        }

        public Task<Model.Assignment> GetTestById(int testid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Test>> GetTests<T>(T Target)
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(Test updatingtest)
        {
            throw new NotImplementedException();
        }
    }
}
