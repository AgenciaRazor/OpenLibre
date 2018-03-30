using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLibre
{
    /// <summary>
    /// Classe que representa os livros 
    /// </summary>
    public class Livros
    {

        #region Membros Publicos 
        /// <summary>
        /// Codigo Do Livro
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Nome do Livro
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// Nome Do Autor do livro
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Editora do Livro
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// Codigo do Autor 
        /// </summary>
        public int Codigo_Autor { get; set; }
        /// <summary>
        /// Estado do livro
        /// </summary>
        public string Estado { get; set; }

        #endregion



        #region Construtor Padrão
        /// <summary>
        /// Construtor padrão 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="autor"></param>
        /// <param name="editora"></param>
        public Livros(int codigo,string nome, string autor,string ISBN, string Estado) 
        {
            this.Codigo = codigo;
            this.nome = nome;
            this.Autor = autor;
            this.ISBN = ISBN;
            this.Estado = Estado;
        }
        #endregion


    }
}
