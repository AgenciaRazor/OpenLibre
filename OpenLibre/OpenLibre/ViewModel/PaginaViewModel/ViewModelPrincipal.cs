using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// View Model para PaginaPrincipal
    /// </summary>
    public class ViewModelPrincipal : BaseViewModel
    {

        #region Comandos
        
        /// <summary>
        /// Comando GoLivro que vai pro proximo View Model
        /// </summary>
        public ICommand Comando_livro { get; set; }
        /// <summary>
        /// Comando que vai pra cadastro Livros
        /// </summary>
        public ICommand Comando_Cadastro_Usuario { get; set; }
        /// <summary>
        /// Comando que vai pra Proxima Pagina
        /// </summary>
        public ICommand Comando_Aluguel { get; set; }

        #endregion

        #region Membros Publicos 

        /// <summary>
        /// Funcionario Atual
        /// </summary>
        public Funcionario Funcionario_Atual { get; set; }

        #endregion

        #region Construtor
        /// <summary>
        /// Construtor Padrão 
        /// </summary>
        public ViewModelPrincipal()
        {
            Funcionario_Atual = new Funcionario("Allan");
            Comando_livro = new RelayCommand(() => GotoPaginaLivro());
            Comando_Cadastro_Usuario = new RelayCommand(() => GotoCdUser());
            Comando_Aluguel = new RelayCommand(() => GotoAluguel());
        }

        #endregion

        #region Metodos 
        /// <summary>
        /// Vai Para Livros
        /// </summary>
        public void GotoPaginaLivro()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Livros;
        }
        /// <summary>
        /// Vai para user
        /// </summary>
        public void GotoCdUser()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.registroUser; 
        }
        /// <summary>
        /// Comando que vai pra Pagina Aluguel 
        /// </summary>
        public void GotoAluguel()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Aluguel;
        }
        #endregion


    }
}
