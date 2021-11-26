using EHS.DbContexts;
using System;
using AutoMapper;

namespace EHS.DataAccess.DAService.Core
{
    public class BaseDAService
    {
        protected readonly EHSContext _dbContext;
        protected readonly IMapper _autoMapper;
        public BaseDAService(EHSContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _autoMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public BaseDAService(EHSContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }
    }
}
