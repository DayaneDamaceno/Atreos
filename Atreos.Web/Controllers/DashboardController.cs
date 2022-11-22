using System.Collections.Generic;
using System.Threading.Tasks;
using Atreos.Infra.Helix;
using Atreos.Web.DAO;
using Atreos.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atreos.Web.Controllers
{
  public class DashboardController : Controller
  {
    // GET
    public async Task<IActionResult> Index()
    {
      var dashboardDao = new DashboardDAO();
      var dadosDashboard = new DashboardViewModel();
      dadosDashboard.MediaHorarioEntrada = dashboardDao.ObterMediaDoHorárioDeEntradaSemestral();
      return View(dadosDashboard);
    }

    public JsonResult CarregarDashboard()
    {
      var dashboardDao = new DashboardDAO();
      var dadosDashboard = new DashboardViewModel();
      
      dadosDashboard.MediaHorarioEntrada = dashboardDao.ObterMediaDoHorárioDeEntradaSemestral();
      dadosDashboard.PresencaPorDiaNoMes = dashboardDao.ObterPresencaPorDiaNoMes();
      dadosDashboard.FrequenciaPorDisciplina = dashboardDao.FrequenciaPorDisciplina();

      var diasDoMes = new List<int>();
      var totalPorDia = new List<int>();
      foreach (var presenca in dadosDashboard.PresencaPorDiaNoMes)
      {
        diasDoMes.Add(presenca.Dia.Day);
        totalPorDia.Add(presenca.Total);
      }
      
      var porcentagens = new List<decimal>();
      var disciplinas = new List<string>();
      foreach (var frequencia in dadosDashboard.FrequenciaPorDisciplina)
      {
        porcentagens.Add(frequencia.Porcentagem);
        disciplinas.Add(frequencia.NomeDisciplina);
      }

      var presencaPorDiaNoMes = new { diasDoMes, totalPorDia };
      var frequenciaPorDisciplina = new { porcentagens, disciplinas };

      return new JsonResult(new {presencaPorDiaNoMes, frequenciaPorDisciplina});
    }
  }
}