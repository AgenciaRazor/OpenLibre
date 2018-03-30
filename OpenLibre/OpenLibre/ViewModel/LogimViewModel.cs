
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// View Model para Pagina de Logim 
    /// </summary>
    public class LogimViewModel : BaseViewModel
    {

        #region Membros Privados
        /// <summary>
        /// Nome do Usuario
        /// </summary>
        private string nUsuario { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        private SecureString nSenha { get; set; }
        /// <summary>
        /// Cria uma instancia de Autenticação
        /// </summary>
        IServicodeAutenticacao Servico = new AutenticacaoDeServico();
        #endregion

        #region Membros Publicos
        /// <summary>
        /// Valor nulo
        /// </summary>
        public string ValorVazio { get; set; } = "";

        /// <summary>
        /// Membro publico para mudança 
        /// </summary>
        public string Usuario
        {
            get { return nUsuario; }
            set
                {
                if (nUsuario != value)
                {
                    nUsuario = value;
                    onpropertyChange("Usuario");
                }
            }
        }
        /// <summary>
        /// Senha que ira conter o usuario
        /// </summary>
        public SecureString senha
        {
            get { return nSenha; }
            set
            {
                if(nSenha != value)
                {
                    nSenha = value;
                    onpropertyChange("senha");
                }
            }
        }
        
        #endregion

        #region Comandos
        /// <summary>
        /// Comando para Logar 
        /// </summary>
        public ICommand Comando_Conectar { get; set; }

        /// <summary>
        /// Comando pra Registrar
        /// </summary>
        public ICommand Comando_Registrar { get; set; }

        #endregion

        #region Construtor
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public LogimViewModel()
        {
            Comando_Registrar = new RelayCommand(() => PaginaDeRegistro());
            Comando_Conectar = new RelayCommand(() => Conectar());
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa a pagina 
        /// </summary>
        public void PaginaDeRegistro()
        {
            // Vai pra proxima pagina 
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Registro;
            
        }
        /// <summary>
        /// Funcão para conectar
        /// </summary>
        public void Conectar()
        {
            // se Usuario é senha estiver correto 
            if(Servico.logim(Usuario,senha))
            {
                /// Vai pra Pagina Princiapl Do pograma
                ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Pagina;
            }
            else
            {
                Usuario = "";
                ValorVazio = "Dados Incorretos";
                onpropertyChange("Usuario");
                onpropertyChange("ValorVazio");
            }
        }

#endregion

    }
}
