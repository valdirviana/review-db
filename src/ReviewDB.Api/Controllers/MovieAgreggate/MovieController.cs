using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewDB.Application.Interfaces.MovieAgreggate;
using ReviewDB.Domain.Core.Bus;
using ReviewDB.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewDB.Api.Controllers.MovieAgreggate
{
    public class MovieController : ApiController
    {
        private readonly IMovieAppService _movieAppService;

        public MovieController(
            IMovieAppService movieAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _movieAppService = movieAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("movie")]
        public IActionResult Get()
        {
            return Response(_movieAppService.GetListAsync());
        }
    }
}
