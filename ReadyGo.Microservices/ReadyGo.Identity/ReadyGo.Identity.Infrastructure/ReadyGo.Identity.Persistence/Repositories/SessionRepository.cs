//using Microsoft.EntityFrameworkCore;
//using ReadyGo.Identity.Domain.Abstractions.Repositories;
//using ReadyGo.Identity.Domain.Aggregates;
//using ReadyGo.Identity.Persistence.Contexts;

//namespace ReadyGo.Identity.Persistence.Repositories
//{
//    public class SessionRepository : ISessionRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public SessionRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IReadOnlyCollection<Session>> GetAsync(Guid userId, CancellationToken cancellation = default)
//        {
//            return await _context.Sessions.Where(x => x.UserId == userId)
//                                          .ToArrayAsync(cancellation);
//        }

//        public async Task<Session> GetAsync(Guid userId, Guid sessionId, CancellationToken cancellation = default)
//        {
//            return await _context.Sessions.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == sessionId, cancellation) ??
//                   throw new SessionNotFoundDomainException();
//        }
//        public async Task AddAsync(Session session, CancellationToken cancellation = default)
//        {
//            if (session == null)
//                throw new SessionNullDomainException();

//            if ((await _context.Sessions.AddAsync(session)).State != EntityState.Added)
//                throw new SessionNotAddedDomainException();
//        }

//        public async Task DeleteAsync(Guid userId, Guid sessionId, CancellationToken cancellation = default)
//        {
//            Session session = await GetAsync(userId, sessionId, cancellation);

//            if (_context.Sessions.Remove(session).State != EntityState.Deleted)
//                throw new SessionNotDeletedDomainException();
//        }

//    }
//}
