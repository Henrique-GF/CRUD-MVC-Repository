using EstoqueVeiculo.DataAccess.Data;
using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public class VeiculoRepositorio : Repositorio<Veiculo>, IVeiculoRepositorio
    {
        private readonly Contexto _contexto;
        public VeiculoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(Veiculo veiculo)
        {
            var veiculoDB = _contexto.Veiculo.FirstOrDefault(x => x.Id == veiculo.Id);
            if (veiculoDB != null)
            {
                veiculoDB.Placa = veiculo.Placa;
                veiculoDB.Marca = veiculo.Marca;
                veiculoDB.Modelo = veiculo.Modelo;
                veiculoDB.Versao = veiculo.Versao;
                veiculoDB.AnoFabricacao = veiculo.AnoFabricacao;
                veiculoDB.AnoModelo = veiculo.AnoModelo;
            }
        }
    }
}
