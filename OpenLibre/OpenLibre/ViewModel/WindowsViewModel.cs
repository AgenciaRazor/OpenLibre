
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// View Model da Janela 
    /// </summary>
    public class WindowsViewModel : BaseViewModel
    {

        #region Membros Privados

        /// <summary>
        /// Configurações sobre a janela
        /// </summary>
        private Window mJanela;
        /// <summary>
        /// margem ao redor da janela
        /// </summary>
        private int mtamanhoMargimFora = 10;
        /// <summary>
        /// Raio da janela ou Radious que são as bordas laterais 
        /// </summary>
        private int mRaioDaJanela = 10;
        

        #endregion

        #region Membros Publicos
        /// <summary>
        /// largura minima em que a janela pode ser diminuida
        /// </summary>
        public double larguraMinima_Da_Janela { get; set; } = 800;
        /// <summary>
        /// o altura minima que pode ser atribuida a janela 
        /// </summary>
        public double AlturaMiima_Da_janela { get; set; } = 550;


        /// <summary>
        /// propriedade que Redimensiona o novo tamanho da borda na janela podendo esticar ao tamanho do usuario
        /// </summary>
        public int RedimensionamentoDaBorda { get; set; } = 6;
        /// <summary>
        /// como os valores para definir as bordas são da Class Thickness se faz necessario criar um objeto do mesmo para nao ocorrer erro na hora do Bliding
        /// property que vai ser usada para recriar o tamanho da Borda
        /// </summary>
        public Thickness RedimensionamentoBordaThickness { get { return new Thickness(RedimensionamentoDaBorda + MargemDeFora); } }
        /// <summary>
        /// Conteudo Da borda
        /// </summary>
        public Thickness Borda_Do_ConTeudoThickness { get { return new Thickness(RedimensionamentoDaBorda); } }
        /// <summary>
        /// ira Blindar com esses itens e Redimensionar para nos 
        /// </summary>
        public int MargemDeFora
        {
            get
            {
                // se estado da nossa janela é Maximizado retornamos o tamanho da margem, caso nao esteja mostrando nenhuma janela apenas usando 0
                return mJanela.WindowState == WindowState.Maximized ? 0 : mtamanhoMargimFora;
            }
            set
            {
                // atribui o valor da margem
                mtamanhoMargimFora = value;
            }
        }
        /// <summary>
        /// Property que ira redimensar o margem de Fora
        /// </summary>
        public Thickness MargemDeForaThickness { get { return new Thickness(MargemDeFora); } }
        /// <summary>
        /// property para definir o raio da janela
        /// </summary>
        public int RaioDaJanela
        {
            get
            {
                // mesma regra vale para para caso a janela esteja Minimizada o retorno sera 0
                return mJanela.WindowState == WindowState.Maximized ? 0 : mRaioDaJanela;
            }
            set
            {
                mRaioDaJanela = value;
            }
        }
        /// <summary>
        /// Configura o Raio da Janela para ser redimensionado pro Valor 10
        /// </summary>
        public CornerRadius RaioDoContoDaJanela { get { return new CornerRadius(RaioDaJanela); } }
        /// <summary>
        /// Property para definir o tamanho da barra localizado em cima 
        /// </summary>
        public int TamanhoDaBarraDeTitulo { get; set; } = 42;
        /// <summary>
        /// atributos para Definir o tamanho da barra do Titulo 
        /// </summary>
        public GridLength BarraDetitulosGrid { get { return new GridLength(TamanhoDaBarraDeTitulo); } }
        /// <summary>
        /// Pagina atual que esta mostrando na applicação 
        /// </summary>
        public PaginaDaApplicacao Pagina_Atual { get; set; } = PaginaDaApplicacao.Logim;
        /// <summary>
        /// Recebe o Funcionario Atual  que esta Logado
        /// </summary>
        public Funcionario Funcionario_Atual { get; set; }

        #endregion

        #region Comandos
        /// <summary>
        /// Minimiza a janela
        /// </summary>
        public ICommand Comando_Minimizar { get; set; }
        /// <summary>
        /// Maximiza a tela 
        /// </summary>
        public ICommand Comando_Maximizar { get; set; }
        /// <summary>
        /// fecha a janela 
        /// </summary>
        public ICommand Comando_Fechar { get; set; }

        #endregion

        #region Construtor
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="janela"></param>
        public WindowsViewModel(Window janela)
        {
            // nossa janela recebe os atributos da janela principal
            this.mJanela = janela;
            mJanela.StateChanged += (sender, e) =>
             {
                 // dispara o evento de mudaça de propriedades sendo assim nossa janela recebe todos esse atributos 
                 onpropertyChange(nameof(Borda_Do_ConTeudoThickness));
                 onpropertyChange(nameof(RedimensionamentoBordaThickness));
                 onpropertyChange(nameof(RedimensionamentoDaBorda));
                 onpropertyChange(nameof(MargemDeFora));
                 onpropertyChange(nameof(MargemDeForaThickness));
                 onpropertyChange(nameof(RaioDaJanela));
                 onpropertyChange(nameof(RaioDoContoDaJanela));

             };
            //comandos para minimizar
            Comando_Minimizar = new RelayCommand(() => mJanela.WindowState = WindowState.Minimized);
            // comando para maximizar
            Comando_Maximizar = new RelayCommand(() => mJanela.WindowState ^= WindowState.Maximized);
            // comando para fechar a janela
            Comando_Fechar = new RelayCommand(() => mJanela.Close());
            
           
        }
        #endregion 

    }
}

