
using AutoMapper;
using Market.Data.Concrete.EntityFramework.Context;

namespace Fahax.Business.Utilities
{
    public class ManagerBase
    {
        public MarketContext DbContext { get; }
        public IMapper Mapper { get; }

        public ManagerBase(IMapper mapper)
        {
            Mapper = mapper;
        }

        public ManagerBase(IMapper mapper, MarketContext context)
        {
            Mapper = mapper;
            DbContext = context;
        }
        public ManagerBase(MarketContext context)
        {
            DbContext = context;
        }
    }
}

