using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryPatternWithUOW.Core.Interfaces;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class ServerTimeNotifier : BackgroundService
    {
        private static readonly TimeSpan Period = TimeSpan.FromSeconds(5);
        private readonly ILogger<ServerTimeNotifier> _logger;
        private readonly IHubContext<ChatHub, IChatHub> _context;

        public ServerTimeNotifier(ILogger<ServerTimeNotifier> logger, IHubContext<ChatHub, IChatHub> context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Period);

            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.Now;

                _logger.LogInformation("Executing {Service} {Time}", nameof(ServerTimeNotifier), dateTime);

                await _context.Clients
                    .User("8dcd28cc-31ce-4d2c-9654-070293746f0d")
                    .RecieveNotification($"Server time = {dateTime}");
            }
        }
    }

}
