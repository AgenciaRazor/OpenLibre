using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// ViewModel para View Registrar 
    /// </summary>
    public class  RegistarViewModel : BaseViewModel
    { 
        #region Membros Publicos
        /// <summary>
        /// Ligação Bd
        /// </summary>
        public BD_Funcionario Bd = new BD_Funcionario();

        /// <summary>
        /// 
        /// </summary>
        public AutenticacaoDeServico Dados = new AutenticacaoDeServico();
        /// <summary>
        /// Senha do Usuário
        /// </summary>
        public SecureString senha { get; set; }

        /// <summary>
        /// Nome a ser Biiding 
        /// </summary>
        public string nome {  get; set;}
        /// <summary>
        /// Property para Tag
        /// </summary>
        public string xnome { get; set; } = "";

        /// <summary>
        /// Property Para Nome do Usuario
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Property Para Tag
        /// </summary>
        public string xUsuario { get; set; } = "";
        /// <summary>
        /// Cpf do Usuário
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// Property para tag 
        /// </summary>
        public string xCpf { get; set; } = "";

        #endregion

        #region Comandos

        /// <summary>
        /// Comando Retorna pra Pagina de Logim
        /// </summary>
        public ICommand Comando_Voltar { get; set; }
        /// <summary>
        /// Comando Para Registrar 
        /// </summary>
        public ICommand Comando_Registrar { get; set; }

        #endregion

        #region Construtor
        /// <summary>
        /// Construtor Padrão 
        /// </summary>
        public RegistarViewModel()
        {
            Comando_Voltar = new RelayCommand(() => Retornar());
            Comando_Registrar = new RelayCommand(() => Registrar());
            senha = new SecureString();
        }

        #endregion

        #region Metodos 
        /// <summary>
        /// comando para registrar
        /// </summary>
        public void Registrar()
        {
            bool teste = true;
            // Testar se nome nao contem 
            if(Validacao_Nome(nome)) // se verdade 
            { 
                 nome = "";
                 onpropertyChange("nome");

                 xnome = "Nome Incorreto";
                teste = false;
                
            }
            // testar se usuario existe
            if(Usuario == null || Usuario == string.Empty || Bd.Verificao_Usuario(Usuario)) // se verdade
            {
                // dandos Incorretos 
                Usuario = "";
                onpropertyChange("Usuario");
                 xUsuario = "Usuário Inválido";
                teste = false;

            }
            //Testar se Cpf é valído
            if(!ValidarCPF(Cpf))
            {
                Cpf = "";
                onpropertyChange("Cpf");
                xCpf = "Cpf Incorreto";
                teste = false;

            }
            
            if(validacao_senha(senha))
            {
                teste = false;
            }

            // se teste for False então 
            if (teste)
            {
                Dados.Registro(Usuario, nome, senha, Cpf);
                MessageBox.Show("Usuário Cadastrado Com Sucesso");
                ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Logim;

            }

            // Codigo pra ligaçao com Banco de dados e testar se Codigo esta Contindo lá.
        }

        /// <summary>
        /// Metodo Para Retorna
        /// </summary>
        public void Retornar()
        {
            // Vai pra proxima pagina 
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Logim;
        }


        #region Metodo Auxiliares 

        /// <summary>
        ///  válida o nome, caso exista algum Numero a aplicação fica inválida
        /// </summary>
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
        /// metodo para descripitogação da senha
        /// </summary>
        /// <param name="Senha"></param>
        /// <returns></returns>
        public bool validacao_senha(SecureString Senha)
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
            if (senhainsegura.Length > 0) return false;
            return true;

            #endregion

        }


    #endregion
    }
    }
