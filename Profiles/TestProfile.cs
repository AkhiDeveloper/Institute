using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Institute.DTOs;
using Institute.Model;

namespace Institute.Profiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<TestCreateForm, Test>();
            CreateMap<TestQuestionCreateForm, TestQuestion>();
        }
    }
}
