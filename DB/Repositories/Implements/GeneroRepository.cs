using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Implements
{
    public class GeneroRepository : BaseRepository<Genero, ChallengeContext>, IGeneroRepository
    {
        public GeneroRepository(ChallengeContext context) : base(context)
        {

        }
    }
}
