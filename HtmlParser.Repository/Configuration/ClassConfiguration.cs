using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Configuration
{
    public class ClassConfiguration : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ClassConfiguration";
            }
        }

        protected override void Configure()
        {
            //Class mapper
            AutoMapper.Mapper.CreateMap<HtmlParser.Repository.@class, HtmlParser.Model.PttClass>()
                .ForMember(x => x.id, y => y.MapFrom(z => z.class_Id))
                .ForMember(x => x.code, y => y.MapFrom(z => z.class_code))
                .ForMember(x => x.name, y => y.MapFrom(z => z.class_name))
                .ForMember(x => x.desc, y => y.MapFrom(z => z.class_desc));

            AutoMapper.Mapper.CreateMap<HtmlParser.Model.PttClass, HtmlParser.Repository.@class>()
                .ForMember(x => x.class_Id, y => y.MapFrom(z => z.id))
                .ForMember(x => x.class_code, y => y.MapFrom(z => z.code))
                .ForMember(x => x.class_name, y => y.MapFrom(z => z.name))
                .ForMember(x => x.class_desc, y => y.MapFrom(z => z.desc));

        }
    }
}
