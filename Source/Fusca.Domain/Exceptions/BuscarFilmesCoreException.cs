using Otc.DomainBase.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

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
        public static readonly BuscarFilmesCoreError LimiteDeRequisicoesAtingido =
            new BuscarFilmesCoreError("LimiteDeRequisicoesAtingido", "O limite de requisições ao provedor de filmes foi atingido, tente novamente mais tarde.");

        public static readonly BuscarFilmesCoreError ParametrosIncorretos =
            new BuscarFilmesCoreError("ParametrosIncorretos", "Os parametros estao incorretos, verifique e tente novamente.");


        protected BuscarFilmesCoreError(string key, string message) : base(key, message)
        {
        }
    }
}
