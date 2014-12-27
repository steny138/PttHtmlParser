using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Configuration
{
    public class ThemeConfiguration : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ThemeConfiguration";
            }
        }

        protected override void Configure()
        {
            //Class mapper
            AutoMapper.Mapper.CreateMap<HtmlParser.Repository.theme, HtmlParser.Model.PttTheme>()
                .ForMember(x => x.id, y => y.MapFrom(z => z.theme_id))
                .ForMember(x => x.boardId, y => y.MapFrom(z => z.board_id))
                .ForMember(x => x.code, y => y.MapFrom(z => z.theme_code))
                .ForMember(x => x.title, y => y.MapFrom(z => z.theme_title))
                .ForMember(x => x.content, y => y.MapFrom(z => z.theme_content))
                .ForMember(x => x.author, y => y.MapFrom(z => z.theme_author))
                .ForMember(x => x.popularity, y => y.MapFrom(z => z.theme_popularity))
                .ForMember(x => x.issueDate, y => y.MapFrom(z => z.theme_issue_date))
                .ForMember(x => x.desc, y => y.MapFrom(z => z.theme_desc));

            AutoMapper.Mapper.CreateMap<HtmlParser.Model.PttTheme, HtmlParser.Repository.theme>()
                .ForMember(x => x.theme_id, y => y.MapFrom(z => z.id))
                .ForMember(x => x.board_id, y => y.MapFrom(z => z.boardId))
                .ForMember(x => x.theme_code, y => y.MapFrom(z => z.code))
                .ForMember(x => x.theme_title, y => y.MapFrom(z => z.title))
                .ForMember(x => x.theme_content, y => y.MapFrom(z => z.content))
                .ForMember(x => x.theme_author, y => y.MapFrom(z => z.author))
                .ForMember(x => x.theme_popularity, y => y.MapFrom(z => z.popularity))
                .ForMember(x => x.theme_issue_date, y => y.MapFrom(z => z.issueDate))
                .ForMember(x => x.theme_desc, y => y.MapFrom(z => z.desc));

        }
    }
}
