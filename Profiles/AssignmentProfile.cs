using AutoMapper;
using Institute.DTOs;
using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Profiles
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<AssignmentCreateForm, Assignment>();
            CreateMap<AssignmentCreateForm, CoursePreAssignment>();
            CreateMap<AssignmentCreateForm, CoursePostAssignment>();
        }
    }
}
