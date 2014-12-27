using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Repository.Configuration
{
    public class BoardConfiguration : AutoMapper.Profile
    {
        public override string ProfileName
        {
            get
            {
                return "BoardConfiguration";
            }
        }

        protected override void Configure()
        {
            //Board mapper
            AutoMapper.Mapper.CreateMap<HtmlParser.Repository.board, HtmlParser.Model.PttBoard>()
                .ForMember(x => x.groupId, y => y.MapFrom(z => z.group_id))
                .ForMember(x => x.id, y => y.MapFrom(z => z.board_id))
                .ForMember(x => x.code, y => y.MapFrom(z => z.board_code))
                .ForMember(x => x.name, y => y.MapFrom(z => z.board_name))
                .ForMember(x => x.manager, y => y.MapFrom(z => z.board_name))
                .ForMember(x => x.popularity, y => y.MapFrom(z => z.board_name))
                .ForMember(x => x.desc, y => y.MapFrom(z => z.board_desc));

            AutoMapper.Mapper.CreateMap<HtmlParser.Model.PttBoard, HtmlParser.Repository.board>()
                .ForMember(x => x.group_id, y => y.MapFrom(z => z.groupId))
                .ForMember(x => x.board_id, y => y.MapFrom(z => z.id))
                .ForMember(x => x.board_code, y => y.MapFrom(z => z.code))
                .ForMember(x => x.board_name, y => y.MapFrom(z => z.name))
                .ForMember(x => x.board_master, y => y.MapFrom(z => z.manager))
                .ForMember(x => x.board_popularity, y => y.MapFrom(z => z.popularity))
                .ForMember(x => x.board_desc, y => y.MapFrom(z => z.desc));

        }
    }
}
