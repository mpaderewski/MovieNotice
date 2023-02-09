using MovieNotice.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNotice.Common.ModelsDto
{
    public class MoviesListDto
    {
        public int Id { get; set; }
        public List<MovieDto> Movies { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
