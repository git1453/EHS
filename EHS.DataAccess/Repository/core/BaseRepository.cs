using EHS.DbContexts;
using System;
using AutoMapper;

namespace EHS.DataAccess.Repository
{
    public class BaseRepository
    {
        protected readonly EHSContext _dbContext;
        protected readonly IMapper _autoMapper;
        public BaseRepository(EHSContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _autoMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public BaseRepository(EHSContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }
    }
}
