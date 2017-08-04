using TechWeek.Infra.CrossbarIo.Connection;
using TechWeek.Infra.CrossbarIo.RPC.Callee;
using TechWeek.Infra.CrossbarIo.Utils.Requests.RPC;
using TechWeek.Service.IPI.Domain;
using TechWeek.Service.IPI.DTOs;

namespace TechWeek.Service.IPI
{
    public class Startup
    {
        private CrossbarConnection _conn;

        public Startup()
        {
            this._conn = new CrossbarConnection();

            this._conn.Initilize(new ConnectionParameters
            {
                ServerAddress = "192.168.1.6",
                Port = 8081,
                ServerRealm = "im_soft"
            });

            var con = this._conn.Connect();

            var res = con.Result;
        }

        public void Configure()
        {
            var calleeICMS = new Callee(this._conn);

            var res = calleeICMS.Run(new CalleeRequest<CalculoIPIRetorno, CalculoIPIParametro>
            {
                NomeMetodo = "br.com.techweek.service.ipi.calc",
                Run = new Calcular().Run
            });
        }
    }
}
