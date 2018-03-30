using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// Base ViewModel
    /// </summary>
    public class ViewModelLivro : BaseViewModel
    {

        #region Membros Privados

        public Bd_Livros bd_Livro = new Bd_Livros();

        /// <summary>
        /// Variavel que irá Conter a pesquisa
        /// </summary>
        private string nPesquisa;
        /// <summary>
        /// Variavel que ira conter o valor do Codigo do livro
        /// </summary>
        private string nCodigo;
        /// <summary>
        /// Private que ira conter o nome do Livro    
        /// <summary>
        /// Codigo
        /// </summary>
        private int xCodigo;

        #endregion

        #region Public Properties 
        /// <summary>
        /// Nome para Tag
        /// </summary>
        public string xnome { get; set; } = "";

        /// <summary>
        /// Property pro nome do Livro
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// tag para autor
        /// </summary>
        public string xautor { get; set; } = "";
        /// <summary>
        /// Property dos Autores
        /// </summary>
       public string autor { get; set; }
        /// <summary>
        /// tag para Isbn
        /// </summary>
        public string xisbn { get; set; } = "";
       /// <summary>
       /// 
       /// </summary>
       public string isbn { get; set; }
        /// <summary>
        /// Tag para Descadastramento
        /// </summary>
        public string xxcodigo { get; set; } = "";

        /// <summary>
        /// Property para Codigo
        /// </summary>
        public string Codigo
        {
            get
            {
                return nCodigo;
            }
            set
            {
             
                nCodigo = value;
                if (Conversao(value)) return;
                xCodigo = int.Parse(value); // xcodigo é uma inteira que ira conter o codigo do autor e livro que irá ser apagado
                onpropertyChange("Codigo");
                onpropertyChange("Item");
            }
        }

        /// <summary>
        /// Pesquisa
        /// </summary>
        public string Pesquisa
        {
            get { return nPesquisa; }
            set
            {

                if (value == null) return;
                nPesquisa = value;
                onpropertyChange("Pesquisa");
                onpropertyChange("ItensFiltrados");
            }
        }
        /// <summary>
        /// contem todos os Dados do livro
        /// </summary>
        public ObservableCollection<Livros> Dados { get; set; }
        /// <summary>
        /// Retorna 
        /// </summary>
        public IEnumerable<Livros> ItensFiltrados
        {
            get
            {
                if (Pesquisa == null) return Dados;
                return Dados.Where(x => x.nome.ToUpper().StartsWith(Pesquisa.ToUpper()));
            }
        }
        /// <summary>
        /// Retona o Item
        /// </summary>
        public IEnumerable<Livros> Item
        {
            get
            {
                if (Codigo == null || Codigo == string.Empty || Codigo == "" || Conversao(Codigo) || ValidacaoDeExistencia(Codigo))
                {
                    xCodigo = 0;
                    return null;
                    
                }
                return Dados.Where(x => x.Codigo == xCodigo);
            }
        }


        #endregion
            
        #region Comando 
        /// <summary>
        /// Comando que vai pra 
        /// </summary>
        public ICommand Comando_Aluguel { get; set; }
        /// <summary>
        /// Comando para Descadastrar Livros
        /// </summary>
        public ICommand Comando_Descadastrar_Livro { get; set; }
        /// <summary>
        /// Comando que volta para casa 
        /// </summary>
        public ICommand Comando_Casa { get; set; }
        /// <summary>
        /// Comando para Cadastrar livro
        /// </summary>
        public ICommand Comando_Cadastro_Livro { get; set; }
        /// <summary>
        /// Comando que vai pra pagina de Registro
        /// </summary>
        public ICommand Comando_UserRegistro { get; set; }

        #endregion Construtor

        #region Construtor
        /// <summary>
        /// Comando para Retorna Pra Casa
        /// </summary>
        public ViewModelLivro()
        {
            // Comando sei lá o que
            Comando_Casa = new RelayCommand(() => VoltaCase());
            Comando_UserRegistro = new RelayCommand(() => vaipraUserRg());
            Comando_Cadastro_Livro = new RelayCommand(() => CadastraLivro());
            Comando_Descadastrar_Livro = new RelayCommand(() => Metodo_Descadastrar());
            Comando_Aluguel = new RelayCommand(() => VaiPraAluguel());
            //Iniciliza Valores do Bd
            Dados = bd_Livro.Db_GetData();
            
        }

        #endregion

        #region Metodos 
        /// <summary>
        /// Volta Pra Casa
        /// </summary>
        public void VoltaCase()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Pagina ;
        }
        /// <summary>
        /// Pagina que vai pro User
        /// </summary>
        public void vaipraUserRg()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.registroUser;
        }
        /// <summary>
        /// Vai para Alguel 
        /// </summary>
        public void VaiPraAluguel()
        {

            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Aluguel;
        }
        /// <summary>
        /// quando clicar no botão cadastro o metodo ativa 
        /// </summary>
        public void CadastraLivro()
        {
            bool teste = true;
            // testar
            if(Validacao_Nome(nome))
            {
                nome = "";
                onpropertyChange("nome");
                xnome = "Valor Incorreto, Digite Apenas caracteres";
                teste = false;
            }
            // testar se o nome do autor é valido
            if (Validacao_Nome(autor))
            {
                autor = "";
                onpropertyChange("autor");
                xautor = "Nome Incorreto";
                teste = false;
            }
            if(validar_isbn(isbn))
            { 
                isbn = "";
                onpropertyChange("isbn");
                xisbn = "ISBN invalido";
                teste = false;
            }
            // se tudo estiver correto, então e executado o comando
            if(teste)
            {
                // cadastra o livro
                bd_Livro.Db_SetDada(Dados.Last().Codigo + 1, nome, autor, isbn, 1);
                // 
                MessageBox.Show("Livro Cadastrado Com Sucesso" +
                    Environment.NewLine + "Codigo do Livro " + (Dados.Last().Codigo + 1).ToString());
                Dados.Add(new Livros(Dados.Count + 1, nome, autor, isbn, "Disponível"));
                onpropertyChange("ItensFiltrados");
                nome = "";
                xnome = "";
                onpropertyChange("nome");
                autor = "";
                xautor = "";
                onpropertyChange("autor");
                isbn = "";
                xisbn = "";
                onpropertyChange("isbn");

            }
           
            
           
        }
        /// <summary>
        /// Exclui do Banco de Dados 
        /// </summary>
        public void Metodo_Descadastrar()
        {
            if(xCodigo == 0)
            {
                Codigo = "";
                onpropertyChange("Codigo");
                xxcodigo = "Valor inválido";
                return;
            }
            string Disponivel = Dados.Where(n => n.Codigo == xCodigo).Select(n => n.Estado).Single(); //contem o valor
            if(Disponivel != "Disponivel")
            {
                Codigo = "";
                onpropertyChange("Codigo");
                xxcodigo = "Livro Precisa Estar Disponível";
                return;
            }
            //
            bd_Livro.Db_DeleteDate(xCodigo);
            MessageBox.Show("O livro foi descadastrado");
            Codigo = "";
            xxcodigo = "";
            //    Dados.Remove(Dados.Where(i => i.Codigo == xCodigo).Single()); // remove 
            Dados = bd_Livro.Db_GetData();
            onpropertyChange("Dados");
            onpropertyChange("ItensFiltrados");
        }


        /// <summary>
        /// Metodo para Teste se valor é válido
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Conversao(string a)
        {
            int Teste = 0;
            try
            {
                Teste = Int32.Parse(a);
            }
            catch (Exception)
            {   
                return true;
            }
           
            return false;

        }
        /// <summary>
        /// Valida se o nome do livr esta certo
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool Validacao_Nome(string nome)
        {
            if (nome == null || nome == string.Empty) return true;
            char cDados = ' ';
            bool Teste = false;
            for (int i = 0; i < nome.Length; i++)
            {
                try
                {
                    cDados = Convert.ToChar(nome.Substring(i, 1));
                    // se for diferente de letra ou espaço entra .
                    if (!char.IsLetter(cDados) && cDados != ' ')
                    {
                        return true;
                    }
                    //  int abc = Convert.ToInt32(nome.Substring(i));
                    //  Teste = true;
                }
                catch (Exception) { }
            }
            return Teste;
        }
        /// <summary>
        /// Metodo para validação de Isbn
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool validar_isbn(string isbn)
        {
            int aux = 0; // variavel auxiliar 
            if (string.IsNullOrEmpty(isbn)) return true; // se string é null então, retorna
            if (isbn.Length != 10) return true; // se o valor é menor que dez, então retorna 
            for (int i = 0; i < isbn.Length; i++) // loop para cada valor da string
            {
                try
                {   // tenta converter, caso nao dé pra converter para int, então é uma string 
                    aux = Convert.ToInt32(isbn.Substring(i, 1));
                }
                catch (Exception)
                {
                   return true; // retornamos true 
                }
            }
            return false; // Isbn
        }
        /// <summary>
        /// Valida se o elemento existe dentro do nosso array 
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public bool ValidacaoDeExistencia(string Valor)
        {
            try
            {
                int a = Int32.Parse(Valor);
                for(int i = 0; i < Dados.Count; i++)
                {
                    if (Dados[i].Codigo == a)
                        return false;
                }
            }
            catch (Exception )
            {

                return true;
            }
            return true;
        }

        #endregion

    }
}
