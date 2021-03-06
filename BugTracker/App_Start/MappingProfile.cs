﻿using AutoMapper;
using BugTracker.Dtos;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Ticket, TicketDto>();
            Mapper.CreateMap<TicketDto, Ticket>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<TicketStatus, TicketStatusDto>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}