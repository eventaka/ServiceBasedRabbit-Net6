using MediatR;
using ServiceBasedRabbit.Core.Dto;
using ServiceBasedRabbit.Core.Interfaces.MessageBroker;
//using ServiceBasedRabbit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBasedRabbit.Infrastructure.CQRS.Commands
{
    /*
    public class OrderQuery : IRequest<IEnumerable<order>>
    {
        #region Parameters 
        public int OrderNo { get; set; }
        public string Phone { get; set; }
        // and so on 
        #endregion



        IOrderService _orderService;
        public OrderQuery(IOrderService orderService)
        {
            _orderService = orderService;
        }



        public class OrderQueryHandler : IRequestHandler<OrderQuery, IEnumerable<order>>
        {
            public async Task<IEnumerable<order>> Handle(OrderQuery request, CancellationToken cancellationToken)
            {
                if (request.OrderNo > 0)
                {
                    return await _orderService.FindByNo(request.OrderNo, cancellationToken);
                }
                return _orderService.FindOrders(request.Phone, cancellationToken);
            }
        }
    }
    */



    /*
      public class CreateUserCommandRequest : IRequest<UserDto>
    {

        #region Parameters 
        public User user { get; set; }
        #endregion



        //private static readonly string[] Summaries = new[]{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};


        //public DateTime DateTime { get; set; }


        //public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQueryRequest, IEnumerable<WeatherForecast>>
        //public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQueryRequest, UserDto>
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, UserDto>
        {
            // private ILogger<GetWeatherForecastQueryHandler> _logger;
            //public GetWeatherForecastQueryHandler(ILogger<GetWeatherForecastQueryHandler> logger)
            public CreateUserCommandHandler()
            {
             //   _logger = logger;
            }


            //public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQueryRequest query, CancellationToken cancellationToken)
            public async Task<UserDto> Handle(CreateUserCommandRequest query, CancellationToken cancellationToken)
            {
                //var dateTime = query.DateTime;
                var dateTime = query.user;
                //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //{
                //    Date = dateTime.AddDays(index),
                //    TemperatureC = Random.Shared.Next(-20, 55),
                //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                //}).ToArray();

                return 
            }
        }
    }
    */


    /*
    public class CreateUserCommandRequest : IRequest<UserDto>
    {

        #region Parameters 
        public User User { get; set; }
        #endregion

        public CreateUserCommandRequest(User user)
        {
            User = user;
        }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, UserDto>
        {

            private readonly IRabbitMQPublisher _publisherMessage;

            public CreateUserCommandHandler(IRabbitMQPublisher publisherMessage)
            {
                _publisherMessage = publisherMessage;
            }


            public async Task<UserDto> Handle(CreateUserCommandRequest cmd, CancellationToken cancellationToken)
            {

                var user = cmd.User;

                UserDto userDto = new UserDto { UserId = user.UserId, UserName = user.UserName };
                _publisherMessage.Send(user);

                return userDto;
            }
        }
    }
    */
}
