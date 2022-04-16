using AutoMapper;
using Boots_Personal_Otomasyon.DAL.Migrations;
using Boots_Personal_Otomasyon.Entities;
using Boots_Personal_Otomasyon.WEBUI.Models;

namespace Boots_Personal_Otomasyon.WEBUI.AutoMapper
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<PersonalVM, Personal>();
            CreateMap<Personal, PersonalVM>();
        }
    }
}
