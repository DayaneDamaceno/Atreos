using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Atreos.Web.Models;

namespace Atreos.Web.Repositories
{
  public abstract class PadraoRepository<T> where T : PadraoViewModel
  {
    protected PadraoRepository()
    {
      SetTabela();
    }
    
    protected string Tabela { get; set; }
    protected string NomeSpListagem => "spListagem";
    protected abstract SqlParameter[] CriaParametros(T model);
    protected abstract T MontaModel(DataRow registro);
    protected abstract void SetTabela();

    public virtual void Insert(T model)
    {
      HelperRepository.ExecutaProc("spInsert_" + Tabela, CriaParametros(model));
    }
    
    public virtual void Update(T model)
    {
      HelperRepository.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
    }
    
    public virtual void Delete(int id)
    {
      var p = new SqlParameter[]
      {
          new("id", id),
          new("tabela", Tabela)
      };
      HelperRepository.ExecutaProc("spDelete", p);
    }
    
    public virtual T Consulta(int id)
    {
      var p = new SqlParameter[]
      {
          new("id", id),
          new("tabela", Tabela)
      };
      var tabela = HelperRepository.ExecutaProcSelect("spConsulta", p);
      return tabela.Rows.Count == 0 ? null : MontaModel(tabela.Rows[0]);
    }
    
    public virtual List<T> Listagem()
    {
      var p = new SqlParameter[]
      {
          new("tabela", Tabela),
          new("Ordem", "1") // 1 é o primeiro campo da tabela
      };
      
      var tabela = HelperRepository.ExecutaProcSelect(NomeSpListagem, p);

      return (from DataRow registro in tabela.Rows select MontaModel(registro)).ToList();
    }
  }
  

}