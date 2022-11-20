using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atreos.Infra.Helix;
using Atreos.Web.DAO;
using Atreos.Web.Models;

namespace Atreos.Infra
{
  public class PresencaService
  {
    private readonly PresencaDAO _presencaDao;
    private readonly CrachaDAO _crachaDao;
    private readonly DisciplinaDAO _disciplinaDao;
    private readonly TotemRepository _totemRepository;

    public PresencaService()
    {
      _totemRepository = new TotemRepository();
      _disciplinaDao = new DisciplinaDAO();
      _presencaDao = new PresencaDAO();
      _crachaDao = new CrachaDAO();
    }

    public async Task RegistrarPresencas()
    {
      var presencasPendentes = new List<PresencaViewModel>();
      
      var dataDaUltimaPresenca = _presencaDao.ObterUltimaPresenca().DataPresenca;
      var totens = await _totemRepository.GetAllTotemsFromDate(dataDaUltimaPresenca);
      if (totens.Any())
      {
        var crachas = totens.Select(t => t.attrValue.Trim()).Distinct().ToList();
        var idsDosAlonoComPresencaPendente = _crachaDao.ObterAlunosComPresencaPendente(crachas);
        var disciplinaAtual = _disciplinaDao.ObterDisciplinaAtual();

        foreach (var aluno in idsDosAlonoComPresencaPendente)
        {
          var registroTotem = totens.FindLast(t => t.attrValue.Trim() == aluno.HexaDec);

          if (registroTotem is not null)
          {
            var presenca = new PresencaViewModel()
            {
                Disciplina = disciplinaAtual,
                Totem = new TotemViewModel { Id = 1 },
                Aluno = aluno.Aluno,
                DataPresenca = registroTotem.recvTime
            };
          
            presencasPendentes.Add(presenca);
          }
        }

        foreach (var presenca in presencasPendentes)
        {
          _presencaDao.Cadastrar(presenca);
        }
      }
    }
  }
}