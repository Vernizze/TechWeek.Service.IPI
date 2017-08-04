using TechWeek.Service.IPI.DTOs;

namespace TechWeek.Service.IPI.Domain
{
    public class Calcular
    {
        public CalculoIPIRetorno Run(CalculoIPIParametro param)
        {
            var valor = 0M;
            var baseCalculo = 0M;

            baseCalculo = (param.ValorItem - (param.ValorItem * (param.ReducaoBaseCalculo / 100)));

            valor = baseCalculo * (param.Aliquota / 100);

            return new CalculoIPIRetorno
            {
                Valor = valor,
                BaseCalculo = baseCalculo
            };
        }
    }
}
