using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using Patrus.Transportes.Treinamento.Vitor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrus.Transportes.Treinamento.Vitor.Services
{
    public class AluguelService : BusinessComponent<AluguelService>
    {
        public void Alugar(long handleAluguel)
        {
            var aluguelRepository = AluguelDao.CreateInstance();
            var aluguel = aluguelRepository.GetForEdit(handleAluguel);
            try
            {
                using (var tc = new TransactionContext())
                {
                    aluguel.Situacao = AluguelSituacaoListaItens.ItemAlugado;
                    aluguel.DataAluguel = BennerContext.Administration.ServerDateTime();
                    if (aluguel.DataPrevistaDevol.GetValueOrDefault() <= BennerContext.Administration.ServerDate())
                        aluguel.DataPrevistaDevol = null;
                    aluguelRepository.Save(aluguel); //Update aqui
                    tc.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Ocorreu um problema ao efetivar a reserva: {ex.Message}", ex);
            }
        }
        public void FinalizarAluguelVeiculo(long handleVeiculo, DateTime dataDevolucao, string responsavelDevolucao)
        {
            var aluguelRepository = AluguelDao.CreateInstance();
            var aluguel = aluguelRepository.Get(a => a.VeiculoHandle == handleVeiculo && a.Situacao == AluguelSituacaoListaItens.ItemAlugado);
            if (dataDevolucao > BennerContext.Administration.ServerDateTime())
                throw new BusinessException("A data de devolução não pode ser superior a data/hora corrente.");
            if (dataDevolucao < aluguel.DataAluguel.GetValueOrDefault())
                throw new BusinessException("A data de devolução não pode ser inferior a data do aluguel.");
            using (var tc = new TransactionContext())
            {
                aluguel.Situacao = AluguelSituacaoListaItens.ItemFinalizado;
                aluguel.ResponsavelDevolucao = responsavelDevolucao;
                aluguel.DataDevolucao = dataDevolucao;
                aluguel.ValorFinal = CalcularValorFinal(aluguel.VeiculoInstance.ValorDiaria.GetValueOrDefault(), aluguel.DataAluguel.GetValueOrDefault(), dataDevolucao, aluguel.ValorInicial.GetValueOrDefault());
                aluguelRepository.Save(aluguel);
                tc.Complete();
            }
        }
        private decimal CalcularValorFinal(decimal valorDiaria, DateTime dataAluguel, DateTime dataDevolucao, decimal valorInicial)
        {
            var qtDias = (dataDevolucao - dataAluguel).Days;
            if (qtDias == 0)
                qtDias = 1;
            return (valorDiaria * qtDias) - valorInicial;
        }
    }
}