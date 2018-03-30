using System;
using System.Runtime.InteropServices;
using System.Security;


namespace OpenLibre
{
    /// <summary>
    /// Autentifica Usuario e senha do Funcionario 
    /// </summary>
    public class AutenticacaoDeServico : IServicodeAutenticacao
    {

        /// <summary>
        /// Objeto pra Comunicação com Banco de Dados 
        /// </summary>
        public BD_Funcionario Ligacao_BD = new BD_Funcionario();

        /// <summary>
        /// Metodo que validara o logim e a senha
        /// </summary>
        /// <param name="Usuario">logim do usario</param>
        /// <param name="Senha">senha do usario</param>
        /// <returns></returns>
        public bool logim(string Usuario, SecureString Senha)
        {
            IntPtr SenhaBSTR = default(IntPtr);
            string senhainsegura = "";
            try
            {
                SenhaBSTR = Marshal.SecureStringToBSTR(Senha);
                senhainsegura = Marshal.PtrToStringBSTR(SenhaBSTR);
            }
            catch (Exception)
            {

                senhainsegura = "";
            }
            return LigacaoBancoDeDados(Usuario, senhainsegura);

        }
        /// <summary>
        /// Metodo para Senha
        /// </summary>
        /// <param name="Usuario">Usuario para logim</param>
        /// <param name="nome">nome do usario</param>
        /// <param name="senha">senha do Usuário</param>
        /// <param name="Celular"></param>
        /// <returns></returns>
        public bool Registro(string Usuario, string nome, SecureString senha, string cpf)
        {
            IntPtr SenhaBSTR = default(IntPtr);
            string senhainsegura = "";
            try
            {
                SenhaBSTR = Marshal.SecureStringToBSTR(senha);
                senhainsegura = Marshal.PtrToStringBSTR(SenhaBSTR);
            }
            catch (Exception)
            {

                senhainsegura = "";
            }
            Ligacao_BD.Dados(nome, Usuario, senhainsegura, cpf);

            return false;

        }
        /// <summary>
        /// Caso a senha seja verdadeira retorna True, Caso nao seja verdadeira Falso
        /// </summary>
        /// <param name="usario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public  bool LigacaoBancoDeDados(string usario,string senha)
        {
            if (Ligacao_BD.Conexao(usario,senha)) return true;
            return false;
        }

        
    }
}
