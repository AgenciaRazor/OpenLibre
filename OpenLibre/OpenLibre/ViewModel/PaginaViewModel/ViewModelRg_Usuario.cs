using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// ViewModel Da Pagina de Cadastro de Usuário
    /// </summary>
    public class ViewModelRg_Usuario : BaseViewModel
    {
        
        #region Membros publicos
        
        /// <summary>
        /// Contem todos os Usuarios Cadastrado No sistema
        /// </summary>
        public ObservableCollection<Usuario> item { get; set; }
        /// <summary>
        /// Instancia do Banco de Dados
        /// </summary>
        public BD_Usuario Bd_Usario = new BD_Usuario();

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public string nome { get; set; }
        /// <summary>
        /// propriedade para indicar messagem de erro
        /// </summary>
        public string xnome { get; set; } = "";
        /// <summary>
        /// Cpf do usuário 
        /// </summary>
        public string cpf { get; set; }
        /// <summary>
        ///propriedade para indicar messagem de erro
        /// </summary>
        public string xcpf { get; set; } = "";
        /// <summary>
        /// Celular do Usuário 
        /// </summary>
        public string celular { get; set; }
        /// <summary>
        /// propriedade para indicar messagem de erro
        /// </summary>
        public string xcelular { get; set; }
        #endregion

        #region Comandos
        /// <summary>
        /// comando para Cadastrar
        /// </summary>
        public ICommand Comando_Cadastrar {get;set;}
        /// <summary>
        /// Comando que vai para Alugeu 
        /// </summary>
        public ICommand Comando_Aluguel { get; set; }
        /// <summary>
        /// Comando que vai pra Home
        /// </summary>
        public ICommand Comando_Home { get; set; }
        /// <summary>
        /// Comando que vai pros Livros
        /// </summary>
        public ICommand Comando_livros { get; set; }

        #endregion

        #region Construtor
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public ViewModelRg_Usuario()
        {
            Comando_Home = new RelayCommand(() => VaiParaHome());
            Comando_livros = new RelayCommand(() => met_VaipraLivros());
            Comando_Aluguel = new RelayCommand(() => GotoAluguel());
            Comando_Cadastrar = new RelayCommand(() => Cadastramento());
            item = Bd_Usario.GetDateFromBd();
        }


        #endregion

        #region Metodos

        #region Metodos de Comando
        /// <summary>
        /// Vai para Alugeu
        /// </summary>
        public void GotoAluguel()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Aluguel;
        }
        /// <summary>
        /// Volta pra Pagina Principal
        /// </summary>
        public void VaiParaHome()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Pagina;  
        }
        /// <summary>
        /// Metodo que muda a Pagina Atual para a pagina Livros
        /// </summary>
        public void met_VaipraLivros()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Livros;
        }
        /// <summary>
        /// metodo que é acionada assim que o Botão cadastro é Clicado
        /// </summary>
        public void Cadastramento()
        {
            bool teste = true;
            // testa se o nome esta valídado
            if(Validacao_Nome(nome))
            {
                nome = "";
                onpropertyChange("nome");
                xnome = "Nome Incorreto";
                teste = false;
            }
            // testa se o cpf esta correto
            if(!ValidarCPF(cpf))
            {
                cpf = "";
                onpropertyChange("cpf");
                xcpf = "Cpf Incorreto";
                teste = false;
            }
            if(validar_Numero(celular))
            {
                celular = "";
                onpropertyChange("celular");
                xcelular = "Numero Incorreto";
                teste = false;
            }
            // se teste for true indica então que os dados estão todos Corretos 
            if(teste)
            {
                //envia os dados para o banco
                Bd_Usario.DadosParaBanco(item.Last().codigo + 1, nome, cpf, celular, true);
                MessageBox.Show("Usuário Cadastrado Com Sucesso" + Environment.NewLine + "Codigo é " + (item.Last().codigo + 1).ToString());
                nome = "";
                onpropertyChange("nome");
                xnome = "";
                cpf = "";
                onpropertyChange("cpf");
                xcpf = "";
                celular = "";
                onpropertyChange("celular");
                xcelular = "";
            }
            //Propriedades são zeradas

        }

        #endregion

        #region Metodos Auxiliares 
        /// <summary>
        /// metodo para validação de Nome
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
                    if (!char.IsLetter(cDados))
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
        /// Validação de Cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public bool ValidarCPF(string cpf)
        {
            if (cpf == null || cpf == string.Empty)
                return false;

            int soma = 0; //variavel para soma dos pesos com o cpf

            string calculado = ""; //variavel que armazenará os valores dos  ultimos digitos, que serão calculados

            int[] arraycpf = new int[cpf.Length]; //array que armazena cada elemento da variavel cpf

            if (cpf.Length != 11) //se a variavel cpf tiver uma quantidade de  caracteres diferente de 11 o programa retorna falso

                return false; //retornando falso

            switch (cpf) //pegando a variavel cpf para ver se os numeros

            {

                case "11111111111": //caso cpf digitado tenha 11 caracteres,porem valores iquais em todos os caracteres, retornar falso

                case "22222222222":

                case "33333333333":

                case "44444444444":

                case "55555555555":

                case "66666666666":

                case "77777777777":

                case "88888888888":

                case "99999999999":

                case "00000000000":

                    return false; //retornando falso para o sistema

            }
            try // //um try cach para pegar as exceções do codigo a seguir
            {
                for (int i = 0; i < arraycpf.Length; i++)
                    arraycpf[i] = Convert.ToInt32(cpf.Substring(i, 1));
            }
            catch (Exception)
            {

                return false;
            }

            for (int j = 10, i = 0; i < 9; i++, j--)
                soma += (arraycpf[i] * j);
            int resto = soma % 11;
            if (resto == 1 || resto == 0) calculado = 0.ToString();
            else calculado = (11 - resto).ToString();
            soma = 0;

            for (int j = 11, i = 0; i < 10; i++, j--)
                soma += (j * arraycpf[i]);
            resto = soma % 11;
            if (resto == 1 || resto == 0) calculado += 0.ToString();
            else calculado += (11 - resto).ToString();
            if ((arraycpf[9].ToString() + arraycpf[10].ToString()) == calculado)
                return true;
            else return false;
        }
        /// <summary>
        /// Validação do numero
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool validar_Numero(string isbn)
        {
            int aux = 0; // variavel auxiliar 
            if (string.IsNullOrEmpty(isbn)) return true; // se string é null então, retorna
            if (isbn.Length != 11) return true; // se o valor é menor que dez, então retorna 
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

        #endregion

        #endregion


    }
}
