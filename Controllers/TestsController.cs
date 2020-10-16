using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Institute.Data;
using Institute.Model;
using Institute.Repository.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Institute.Controllers
{
    [Route("api/tests")]
    [ApiController]
    public class TestsController : ControllerBase
    {

        private readonly IInstituteDataRepoCRUD _datarepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public TestsController
            (IInstituteDataRepoCRUD repository,
            IMapper mapper,
            IFileManager fileManager)
        {
            _datarepository = repository;
            _mapper = mapper;
            _fileManager = fileManager;
        }

        //Tutor
        [Authorize(Roles = "Tutor")]
        [Authorize(Policy ="TestAuthorCheck")]
        [HttpPost("question")]
        public async Task<IActionResult> PostQuestion(
            string testcode,
            DTOs.TestQuestionCreateForm testQuestion)
        {
            try
            {
                //Mapping to model
                var questionmodel = _mapper.Map<Question>(testQuestion);
                var testQuestionmodel = _mapper.Map<TestQuestion>(testQuestion);
                var testmodeltask = _datarepository.GetTestByCode(testcode);

                //Configuring datas to testQA model
                testQuestionmodel.Question = questionmodel;
                var testmodel = await testmodeltask;
                testQuestionmodel.RefTest = testmodel;

                //Writing to database
                await _datarepository.CreateTestQuestion(testQuestionmodel);
                await _datarepository.SaveChanges();

                return Ok(testmodel);
            }
            catch(Exception e)
            {
                throw new ArgumentNullException("Fail to complete", e);
            }
            
        }


        //[Authorize(Roles = "Tutor")]
        //[HttpPost("correctanswer")]
        //public async Task<IActionResult> PostCorrectAnswer(
        //    string testcode,
        //    DTOs.AnswerCreateDTO answer)
        //{

        //}
    }
}
