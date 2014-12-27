using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Configuration
{
    public class PushConfiguration : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get
            {
                return "PushConfiguration";
            }
        }

        protected override void Configure()
        {
            //Push mapper
            AutoMapper.Mapper.CreateMap<HtmlParser.Repository.push, HtmlParser.Model.PttThemePush>()
                .ForMember(x => x.themeId, y => y.MapFrom(z => z.theme_id))
                .ForMember(x => x.id, y => y.MapFrom(z => z.push_id))
                .ForMember(x => x.author, y => y.MapFrom(z => z.push_author))
                .ForMember(x => x.content, y => y.MapFrom(z => z.push_content))
                .ForMember(x => x.pushType, y => y.MapFrom(z => z.push_type))
                .ForMember(x => x.pushDate, y => y.MapFrom(z => z.push_date));

            AutoMapper.Mapper.CreateMap<HtmlParser.Model.PttThemePush, HtmlParser.Repository.push>()
                .ForMember(x => x.theme_id, y => y.MapFrom(z => z.themeId))
                .ForMember(x => x.push_id, y => y.MapFrom(z => z.id))
                .ForMember(x => x.push_author, y => y.MapFrom(z => z.author))
                .ForMember(x => x.push_content, y => y.MapFrom(z => z.content))
                .ForMember(x => x.push_type, y => y.MapFrom(z => z.pushType))
                .ForMember(x => x.push_date, y => y.MapFrom(z => z.pushDate));

        }
    }
}
