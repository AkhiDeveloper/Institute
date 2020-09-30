using AutoMapper;
using Institute.DTOs;
using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            //Course DTOs
            // Source -> DTO
            CreateMap<Course, CourseReadDTO>();
            CreateMap<Course, CourseUpdateDTO>();
            //DTO -> Source
            CreateMap<CourseRequestForm, Course>();
            CreateMap<CourseUpdateDTO, Course>();

            //Chapter DTOs
            CreateMap<Chapter, ChapterReadDTO>();
            CreateMap<Chapter, ChapterUpdateDTO>();
            CreateMap<ChapterCreateForm, Chapter>();
            CreateMap<ChapterUpdateDTO, Chapter>();
        }
    }
}
