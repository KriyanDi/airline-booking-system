using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Context;
using WebAbsApi.Contracts;

namespace WebAbsApi.Repository
{
    public class AbsRepository : IAbsRepository
    {
        private readonly DapperContext _context;

        public AbsRepository(DapperContext context)
        {
            _context = context;
        }
    }
}
