
using System.Security;


namespace OpenLibre
{
    /// <summary>
    /// Interface para Autencicação de Serviço do
    /// </summary>
    public interface IServicodeAutenticacao
    {
        bool logim(string Usuario, SecureString Senha);

        bool Registro(string Usuario,string nome,SecureString senha,string Celular);
    }
}
