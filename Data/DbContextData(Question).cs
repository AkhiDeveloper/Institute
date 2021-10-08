using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData
        
    {
        public async Task CreateCorrectAnswer(CorrectAnswer correctanswer)
        {
            await _context.AddAsync<CorrectAnswer>(correctanswer);
        }

        public async Task CreateWrongAnswer(WrongAnswer wrongAnswer)
        {
            await _context.AddAsync<WrongAnswer>(wrongAnswer);
        }

        public async Task<Question> GetQuestionByCode
            (string questioncode)
        {
            var result = await _context.Questions
                .FirstOrDefaultAsync(x => x.Code == questioncode);
            return result;
        }
    }
}
