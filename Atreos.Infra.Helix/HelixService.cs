using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Atreos.Infra.Helix.Entities;

namespace Atreos.Infra.Helix
{
  public class HelixService
  {
    private readonly HttpClient _httpClient;

    public HelixService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

  }
}