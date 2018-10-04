using Otc.DomainBase.Exceptions;

namespace Fusca.Domain.Exceptions
{
    public class BuscarFilmesCoreException : CoreException<BuscarFilmesCoreError>
    {
        public BuscarFilmesCoreException(BuscarFilmesCoreError buscarFilmesCoreError)
        {
            AddError(buscarFilmesCoreError);
        }
    }

    public class BuscarFilmesCoreError : CoreError
    {
        public static BuscarFilmesCoreError LimiteDeRequisicoesAtingido =>
            new BuscarFilmesCoreError("LimiteDeRequisicoesAtingido", "O limite de requisições ao provedor de filmes foi atingido, tente novamente mais tarde.");

        public static BuscarFilmesCoreError ParametrosIncorretos =>
            new BuscarFilmesCoreError("ParametrosIncorretos", "Os parametros estao incorretos, verifique e tente novamente.");


        protected BuscarFilmesCoreError(string key, string message) : base(key, message)
        {
        }
    }
}
