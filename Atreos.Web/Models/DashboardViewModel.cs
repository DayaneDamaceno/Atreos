using System;
using System.Collections.Generic;

namespace Atreos.Web.Models
{
  public class DashboardViewModel
  {
    public DateTime? MediaHorarioEntrada { get; set; }
    public List<PresencaPorDiaNoMesViewModel> PresencaPorDiaNoMes { get; set; }
    public List<FrequenciaPorDisciplinaViewModel> FrequenciaPorDisciplina { get; set; }
  }
}