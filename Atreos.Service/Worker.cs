using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        var totemRepository = new TotemRepository();
        var totens = await totemRepository.GetAllTotems();
        
        _logger.LogInformation("Quantidade: {c}", totens.Count);
        await Task.Delay(5000, stoppingToken);
      }
    }
  }
}