﻿using ReadyGo.Identity.Application.Abstractions.Providers;
using ReadyGo.Identity.Persistence.Abstractions.Repositories;
using ReadyGo.Identity.Persistence.Entities;
using ReadyGo.Identity.Outbox.Abstractions.Backgrounds;
using ReadyGo.Identity.Domain.Abstractions.Events;
using Newtonsoft.Json;
using ReadyGo.Identity.Domain.Abstractions.Repositories;

namespace ReadyGo.Identity.Outbox.Backgrounds
{
    public class OutboxBackground : IOutboxBackground
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
        };

        private readonly IOutboxRepository _outboxRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ITimeProvider _timeProvider;

        public OutboxBackground(IOutboxRepository outboxRepository, 
                                IUnitOfWork unitOfWork,
                                ITimeProvider timeProvider)
        {
            _outboxRepository = outboxRepository;
            _unitOfWork = unitOfWork;
            _timeProvider = timeProvider;
        }

        public async Task HandleAsync(CancellationToken cancellation)
        {
            OutboxMessage? outboxMessage = await _outboxRepository.LockNextOutboxMessageAsync(_timeProvider.NowUnix(), 
                                                                                              cancellation);

            if (outboxMessage == null)
                return;

            IDomainEvent domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(outboxMessage.Payload, 
                                                                                   _jsonSerializerSettings)!;

            try
            {
                //await publisher.Publish(domainEvent);
                outboxMessage.MarkAsProccesed();
                await _unitOfWork.SaveAsync();
            }
            catch
            {

            }
        }
    }
}
