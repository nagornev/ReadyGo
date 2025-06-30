//using Microsoft.EntityFrameworkCore;
//using ReadyGo.Identity.Domain.Abstractions.Repositories;
//using ReadyGo.Identity.Domain.Aggregates;
//using ReadyGo.Identity.Persistence.Contexts;

//namespace ReadyGo.Identity.Persistence.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public UserRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        /// <summary>
//        /// Returns user by <paramref name="userId"/>.
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="cancellation"></param>
//        /// <returns></returns>
//        /// <exception cref="UserNotFoundDomainException"></exception>
//        public async Task<User> GetAsync(Guid userId, CancellationToken cancellation = default)
//        {
//            return await _context.Users.Include(x => x.Authentication)
//                                       .Include(x => x.Authorization)
//                                           .ThenInclude(x => "_rolePermissions")
//                                       .Include(x => x.Authorization)
//                                           .ThenInclude(x => "_scopePermissions")
//                                       .Include(x => x.Profile)
//                                       .FirstOrDefaultAsync(x => x.Id == userId, cancellation) ??
//                   throw new UserNotFoundDomainException(userId);
//        }

//        /// <summary>
//        /// Adds a new <paramref name="user"/> to the context, but does not yet exist in the database.
//        /// </summary>
//        /// <param name="user"></param>
//        /// <param name="cancellation"></param>
//        /// <returns></returns>
//        /// <exception cref="UserNullDomainException"></exception>
//        /// <exception cref="UserNotAddedDomainException"></exception>
//        public async Task AddAsync(User user, CancellationToken cancellation = default)
//        {
//            if (user == null)
//                throw new UserNullDomainException();

//            if ((await _context.Users.AddAsync(user, cancellation)).State != EntityState.Added)
//                throw new UserNotAddedDomainException();
//        }

//        /// <summary>
//        /// Marks user for deletion from the database by <paramref name="userId"/>.
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="cancellation"></param>
//        /// <returns></returns>
//        /// <exception cref="UserNotFoundDomainException"></exception>
//        /// <exception cref="UserNotDeletedDomainException"></exception>
//        public async Task DeleteAsync(Guid userId, CancellationToken cancellation = default)
//        {
//            User user = await GetAsync(userId, cancellation);

//            if ((_context.Users.Remove(user)).State != EntityState.Deleted)
//                throw new UserNotDeletedDomainException();
//        }
//    }
//}
