using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLibre
{
    /// <summary>
    /// Classe para Representar Usuario
    /// </summary>
    public class Usuario
    {
        
        #region Membros Publicos 
        /// <summary>
        /// Codigo do Usuário
        /// </summary>
        public int codigo { get; set; }

        /// <summary>
        /// Nome do Usário
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Cpf do Funcionario
        /// </summary>
        public string cpf { get; set; }

        /// <summary>
        /// Celular
        /// </summary>
        public string celular { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool estado { get; set; }

        #endregion

        #region Construtor 

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo">Codigo do Usuario</param>
        /// <param name="nome">Nome Do Usário</param>
        /// <param name="cpf">Cpf do Funcionario</param>
        /// <param name="celular">Celular Do Funcionario</param>
        /// <param name="estado">Estado que se encontra o Funcionario caso tenho mais de <see cref="Livros"/></param>
        public Usuario(int codigo, string nome, string cpf, string celular, bool estado)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.cpf = cpf;
            this.celular = celular;
            this.estado = estado;

        }

    }
        #endregion
    }
