//using Microsoft.EntityFrameworkCore;
//using ReadyGo.Identity.Domain.Abstractions.Repositories;
//using ReadyGo.Identity.Domain.Aggregates;
//using ReadyGo.Identity.Persistence.Contexts;

//namespace ReadyGo.Identity.Persistence.Repositories
//{
//    public class ScopeRepository : IScopeRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public ScopeRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IReadOnlyCollection<Scope>> GetAsync(CancellationToken cancellation = default)
//        {
//            return await _context.Scopes.ToArrayAsync(cancellation);
//        }

//        /// <summary>
//        /// Returns scope by <paramref name="scopeId"/>.
//        /// </summary>
//        /// <param name="scopeId"></param>
//        /// <param name="cancellation"></param>
//        /// <returns></returns>
//        /// <exception cref="ScopeNotFoundDomainException"></exception>
//        public async Task<Scope> GetAsync(int scopeId, CancellationToken cancellation = default)
//        {
//            return await _context.Scopes.FirstOrDefaultAsync(x => x.Id == scopeId, cancellation) ??
//                   throw new ScopeNotFoundDomainException();
//        }
//    }
//}
