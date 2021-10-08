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
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IInstituteDataRepoCRUD _datarepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public QuestionsController
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
        [HttpPost("rightanswer")]
        public async Task<IActionResult> PostRightAnswer(
            string questioncode, 
            DTOs.AnswerCreateDTO answerform)
        {
            //Mapping to model
            var answer = _mapper.Map<Answer>(answerform);
            var correctanswer = _mapper.Map<CorrectAnswer>(answerform);

            //Getting Qsn from database
            var question = await _datarepository
                .GetQuestionByCode(questioncode);

            //Assigning to correct answer
            correctanswer.Answer = answer;
            correctanswer.RefQsn = question;

            //Creating correct answer
            await _datarepository.CreateCorrectAnswer(correctanswer);
            await _datarepository.SaveChanges();

            return Ok(correctanswer);

        }

        [Authorize(Roles = "Tutor")]
        [HttpPost("rightanswer")]
        public async Task<IActionResult> PostWrongAnswer(
            string questioncode,
            DTOs.AnswerCreateDTO answerform)
        {
            //Mapping to model
            var answer = _mapper.Map<Answer>(answerform);
            var wronganswer = _mapper.Map<WrongAnswer>(answerform);

            //Getting Qsn from database
            var question = await _datarepository
                .GetQuestionByCode(questioncode);

            //Assigning to correct answer
            wronganswer.Answer = answer;
            wronganswer.RefQsn = question;

            //Creating correct answer
            await _datarepository.CreateWrongAnswer(wronganswer);
            await _datarepository.SaveChanges();

            return Ok(wronganswer);

        }
    }
}
