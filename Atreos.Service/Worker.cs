using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Atreos.Infra;
using Atreos.Infra.Helix;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Atreos.Service
{
  public class Worker : BackgroundService
  {
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
      _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        
        var presencaService = new PresencaService();
        
        await presencaService.RegistrarPresencas();

        _logger.LogInformation("Chegou ao fim");
        await Task.Delay(5000, stoppingToken);
      }
    }
  }
}