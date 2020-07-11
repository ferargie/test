using AutoMapper;
using Leave_Management_netCore.Data;
using Leave_Management_netCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management_netCore.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            //Mappear el resto

        }
    }
}
