using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLibre
{
    /// <summary>
    /// Enumerado que Mostrar quantas paginas nossa aplicação ira ter
    
    /// </summary>
    public enum PaginaDaApplicacao
    {
        /// <summary>
        /// Pagina de Logim
        /// </summary>
        Logim = 0,
        /// <summary>
        /// Pagina Principal
        /// </summary>
        Pagina = 1,
        /// <summary>
        /// Pagina De Registro
        /// </summary>
        Registro = 2,
        /// <summary>
        /// Ira Conter Os Dados Dos Livros 
        /// </summary>
        Livros = 3,
        /// <summary>
        /// View Pra Registrar Usuários 
        /// </summary>
        registroUser = 4,
        /// <summary>
        /// View Aluguel
        /// </summary>
        Aluguel = 5

    }
}
