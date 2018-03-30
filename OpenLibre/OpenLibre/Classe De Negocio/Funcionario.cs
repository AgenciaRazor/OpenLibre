using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OpenLibre
{
    /// <summary>
    /// 
    /// </summary>
    public class Funcionario
    {

        /// <summary>
        /// Nome do funcionario
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Nome do Usuario
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Senha do Funcionario
        /// </summary>
        public SecureString Senha { get; set; }
        /// <summary>
        /// Cpf do Funcionario
        /// </summary>
        public int cpf { get; set; }
   
        /// <summary>
        ///Construtor Padrão
        /// </summary>
        /// <param name="nome">Nome Do funcionario</param>
        public Funcionario(string nome)
        {
            this.nome = nome;
        }



    }
}
