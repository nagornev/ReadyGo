using ReadyGo.Identity.Domain.Abstractions.Primitives;
using ReadyGo.Identity.Domain.Failures.Exceptions.Sessions;
using ReadyGo.Identity.Domain.ValueObjects;

namespace ReadyGo.Identity.Domain.Aggregates
{
    public partial class Session : AggregateRoot
    {
        private Session(Guid id,
                        Guid userId,
                        Device device,
                        IpAddress ipAddress,
                        long createdAt)
        {
            Id = id;
            UserId = userId;
            Device = device;
            IpAddress = ipAddress;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Creates new session log.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="device"></param>
        /// <param name="ipAddress"></param>
        /// <param name="createdAt"></param>
        /// <returns></returns>
        public static Session Create(Guid userId,
                                     string device,
                                     string ipAddress,
                                     long createdAt)
        {
            Guid id = Guid.NewGuid();

            return new Session(id,
                               userId,
                               Device.Create(device) ?? throw new DeviceNullDomainException(),
                               IpAddress.Create(ipAddress) ?? throw new IpAddressNullDomainException(),
                               createdAt);
        }

        public Guid UserId { get; private set; }

        public Device Device { get; private set; }

        public IpAddress IpAddress { get; private set; }

        public long CreatedAt { get; private set; }
    }

    #region Ef

    public partial class Session
    {
        private Session()
        {
        }
    }

    #endregion
}
