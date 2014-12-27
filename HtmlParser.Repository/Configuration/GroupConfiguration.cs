using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Configuration
{
    public class GroupConfiguration : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get
            {
                return "GroupConfiguration";
            }
        }

        protected override void Configure()
        {
            //Group mapper
            AutoMapper.Mapper.CreateMap<HtmlParser.Repository.group, HtmlParser.Model.PttGroup>()
                .ForMember(x => x.id, y => y.MapFrom(z => z.group_id))
                .ForMember(x => x.code, y => y.MapFrom(z => z.group_code))
                .ForMember(x => x.name, y => y.MapFrom(z => z.group_name))
                .ForMember(x => x.desc, y => y.MapFrom(z => z.group_desc))
                .ForMember(x => x.id, y => y.MapFrom(z => z.group_previous_id));

            AutoMapper.Mapper.CreateMap<HtmlParser.Model.PttGroup, HtmlParser.Repository.group>()
                .ForMember(x => x.group_id, y => y.MapFrom(z => z.id))
                .ForMember(x => x.group_code, y => y.MapFrom(z => z.code))
                .ForMember(x => x.group_name, y => y.MapFrom(z => z.name))
                .ForMember(x => x.group_desc, y => y.MapFrom(z => z.desc))
                .ForMember(x => x.group_previous_id, y => y.MapFrom(z => z.id));
        }
    }
}
