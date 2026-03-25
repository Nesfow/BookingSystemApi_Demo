namespace BookingSystemApi.Application.Abstractions.Messaging;


// Only one interface as there is no point for Query without a response
public interface IQuery<TResponse>;