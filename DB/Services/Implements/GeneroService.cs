using DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implements
{
    public class GeneroService: GenericService<Genero>, IGeneroService
    {
        private IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository generoRepository) : base(generoRepository)
        {
            this._generoRepository = generoRepository;
        }
    }
}
