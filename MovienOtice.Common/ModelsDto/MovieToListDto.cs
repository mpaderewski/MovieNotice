using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNotice.Common.ModelsDto
{
    public  class MovieToListDto
    {
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string BackdropPath { get; set; }
        public double? Popularity { get; set; }
        public int ListId { get; set; }
    }
}
