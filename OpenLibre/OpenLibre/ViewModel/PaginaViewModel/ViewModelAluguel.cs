using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// View Model Para Comunicação de Dados entre View Aluguel e seus Dados 
    /// </summary>
    public class ViewModelAluguel : BaseViewModel
    {

        #region Dados Do Usuario

        /// <summary>
        /// String para usuario
        /// </summary>
        private string nCodigo_Usuario;
        /// <summary>
        /// Codigo do Usuário Inteiro
        /// </summary>
        private int x_Codigo_Usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Codigo_Usuario
        {
            get { return nCodigo_Usuario; }
            set
            {

                nCodigo_Usuario = value;
                if (Conversao(value)) return; // se o metodo nao for inteiro, entao retorna 
                x_Codigo_Usuario = Int32.Parse(value);
                onpropertyChange("Dados_Usuarios");
            }
        }
        /// <summary>
        /// Tag para ser mostrada na tela 
        /// </summary>
        public string Xcodigo_Usuario { get; set; } = "";
        /// <summary>
        /// Enumerador de livros
        /// </summary>
        public IEnumerable<Livros> Dados_Livro
        {
            get
            {
                if (Codigo_Livro == null || Codigo_Livro == string.Empty || Codigo_Livro == "" || Conversao(Codigo_Livro) || ValidacaoDeExistencia_Livro(Codigo_Livro))
                {
                    x_Codigo_Livro = 0;
                    return null;
                }
                return Dados_Livro_all.Where(n => n.Codigo == x_Codigo_Livro);
            }
        }
        #endregion

        #region Dados do Livro
        /// <summary>
        /// 
        /// </summary>
        private int x_Codigo_Livro;
        /// <summary>
        /// para conter os valores digitados na textbox
        /// </summary>
        private string nCodigo_Livro;
        /// <summary>
        /// Codigo do Livro
        /// </summary>
        public string Codigo_Livro
        {
            get { return nCodigo_Livro; }
            set
            {
                nCodigo_Livro = value;
                if (Conversao(value)) return;
                x_Codigo_Livro = int.Parse(value);
                onpropertyChange("Dados_Livro");

            }
        }
        public string Xcodigo_Livro { get; set; } = "";
        /// <summary>
        /// Contera a tag
        /// </summary>

        public IEnumerable<Usuario> Dados_Usuarios
        {
            get
            {
                if (Codigo_Usuario == null || Codigo_Usuario == string.Empty || Codigo_Usuario == "" || Conversao(Codigo_Usuario) || ValidacaoDeExistencia_Usuario(Codigo_Usuario))
                {
                    x_Codigo_Usuario = 0;
                    return null;
                }

                return Dados_Usuario_all.Where(n => n.codigo == x_Codigo_Usuario);
            }
        }
        #endregion

        #region Dados Do Livro 2
        /// <summary>
        /// 
        /// </summary>
        private int x_Codigo_Livro2;
        /// <summary>
        /// para conter os valores digitados na textbox
        /// </summary>
        private string nCodigo_Livro2;
        /// <summary>
        /// Codigo do Livro
        /// </summary>
        public string Codigo_Livro2
        {
            get { return nCodigo_Livro2; }
            set
            {
                nCodigo_Livro2 = value;
                if (Conversao(value)) return;
                x_Codigo_Livro2 = int.Parse(value);
                onpropertyChange("Dados_Livro2");

            }
        }
        public string Xcodigo_Livro2 { get; set; } = "";
        /// <summary>
        /// Contera a tag
        /// </summary>
        /// </summary>
        public IEnumerable<Livros> Dados_Livro2
        {
            get
            {
                if (Codigo_Livro2 == null || Codigo_Livro2 == string.Empty || Codigo_Livro2 == "" || Conversao(Codigo_Livro2) || ValidacaoDeExistencia_Livro(Codigo_Livro2))
                {
                    x_Codigo_Livro2 = 0;
                    return null;
                }
                return Dados_Livro_all.Where(n => n.Codigo == x_Codigo_Livro2);
            }
        }

        #endregion

        #region Membros Publicos 
        /// <summary>
        /// Liga Com o Banco De Dados 
        /// </summary>
        public Bd_Aluguel bd_Aluguel = new Bd_Aluguel();

        /// <summary>
        /// Contem um Usuario
        /// </summary>
        public ObservableCollection<Usuario> Dados_Usuario_all { get; set; }
        /// <summary>
        /// Dados Do livro
        /// </summary>
        public ObservableCollection<Livros> Dados_Livro_all { get; set; }

        #endregion

        #region Comandos 
        /// <summary>
        /// Comando que vai para Casa
        /// </summary>
        public ICommand Comando_Casa { get; set; }

        /// <summary>
        /// Comando que vai pra livros 
        /// </summary>
        public ICommand Comando_Livro { get; set; }

        /// <summary>
        /// Comando que vai pro Registro do Usuario
        /// </summary>
        public ICommand Comando_CD_Usuario { get; set; }

        /// <summary>
        /// Comando que Aluga um livro 
        /// </summary>
        public ICommand Comando_Aluguel { get; set; }

        /// <summary>
        /// Comando que é usado para Devolver livro
        /// </summary>
        public ICommand Comando_Devolucao { get; set; }
        #endregion

        #region Construtor Padrão 

        /// <summary>
        /// Construtor Padrão 
        /// </summary>
        public ViewModelAluguel()
        {
            Comando_Aluguel = new RelayCommand(() => Alugar());
            Comando_Casa = new RelayCommand(() => GotoCasa());
            Comando_Livro = new RelayCommand(() => GoToLivro());
            Comando_CD_Usuario= new RelayCommand(() => GotoCadastro());
            Comando_Devolucao = new RelayCommand(() => Devolucao());
            Dados_Usuario_all = new BD_Usuario().GetDateFromBd();
            Dados_Livro_all = new Bd_Livros().Db_GetData();
            Codigo_Usuario = "";

        }
        #endregion

        #region Metodo Auxiliares

        /// <summary>
        /// Vai para View Home
        /// </summary>
        public void GotoCasa()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Pagina;

        }
        /// <summary>
        /// vai para View Livros
        /// </summary>
        public void GoToLivro()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.Livros;

        }
        /// <summary>
        /// vai para View Cadastro
        /// </summary>
        public void GotoCadastro()
        {
            ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Pagina_Atual = PaginaDaApplicacao.registroUser;

        }
        /// <summary>
        /// Metodo para Alugar
        /// </summary>
        public void Alugar()
        {
            bool teste = true;
            string element = string.Empty;
            if(x_Codigo_Livro == 0)
            {
                Codigo_Livro = "";
                onpropertyChange("Codigo_Livro");
                Xcodigo_Livro = "Valor Incorreto";
                //Captura Excessão
                teste = false;

            }
            if(x_Codigo_Usuario == 0)
            {
                Codigo_Usuario = "";
                onpropertyChange("Codigo_Usuario");
                Xcodigo_Usuario = "Valor Incorreto";
                //Capturar Excessão 
                teste = false;
            }
            if (teste)
            {
                bool teste2 = true;
                element = Dados_Livro_all.Where(n => n.Codigo == x_Codigo_Livro).Select(n => n.Estado).Single();
                /// verificar se o Usuário está Disponivel 
                if (!Dados_Usuario_all.Where(n => n.codigo == x_Codigo_Usuario).Select(n => n.estado).Single())
                {
                    Codigo_Usuario = "";
                    onpropertyChange("Codigo_Usuario");
                    Xcodigo_Usuario = "Não pode pegar Livro";
                    teste2 = false;
                }
                // verificar se o livro esta Disponivel
                if (element != "disponivel")
                {
                    Codigo_Livro = "";
                    onpropertyChange("Codigo_Livro");
                    Xcodigo_Livro = "Livro Indisponivel";
                    teste2 = false;
                }
                if(teste2) // se for true o valor vai pro banco de dados 
                {

                    bd_Aluguel.Alugar_bd(x_Codigo_Usuario,x_Codigo_Livro);
                    Dados_Livro_all = new Bd_Livros().Db_GetData();
                    Dados_Usuario_all = new BD_Usuario().GetDateFromBd();
                    Codigo_Livro = "";
                    onpropertyChange("Codigo_Livro");
                    Codigo_Usuario = "";
                    onpropertyChange("Codigo_Usuario");
                    MessageBox.Show("Livro Emprestado Com Sucesso");
                    return; // sai do Metodo


                }

            }
            
          


        }
        /// <summary>
        /// Metodo para Devolução 
        /// </summary>
        public void Devolucao()
        {

            bool teste = true;
            // se o valor dá variavel x_Codigo for igual á zero siginifica que o valor na textbox nao foi inteiro e se foi(nao esta dentro dos valores)
            if (x_Codigo_Livro2 == 0)
            {
                Codigo_Livro2 = "";
                onpropertyChange("Codigo_Livro2");
                Xcodigo_Livro2 = "Valor Incorreto";
                teste = false;

            }
            string element = Dados_Livro_all.Where(n => n.Codigo == x_Codigo_Livro2).Select(n => n.Estado).Single();
            if (element == "disponivel")
            {
                Codigo_Livro2 = "";
                onpropertyChange("Codigo_Livro2");
                Xcodigo_Livro2 = "Livro nao foi Emprestado";
                teste = false;
            }
            // envia dados para o banco de dadoss
            if(teste)
            { 
                bd_Aluguel.Devolver_Bd(x_Codigo_Livro2);
                Dados_Livro_all = new Bd_Livros().Db_GetData();
                Dados_Usuario_all = new BD_Usuario().GetDateFromBd();
                Codigo_Livro2 = "";
                onpropertyChange("Codigo_Livro2"); 
                MessageBox.Show("Livro Foi Devolvido"); 

                //
            }


            // se o livro foi emprestado é o valor é valido, então fazemos ligação com o banco de dados e terminamos todo o processo

        }



        /// <summary>
        /// Metodo de Conversão
        /// </summary>
        /// <param name="a">Parametro</param>
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
        /// Verifica se o  valor existe
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public bool ValidacaoDeExistencia_Livro(string Valor)
        {
            try
            {
                int a = Int32.Parse(Valor);
                for (int i = 0; i < Dados_Livro_all.Count; i++)
                {
                    if (Dados_Livro_all[i].Codigo == a)
                        return false;
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public bool ValidacaoDeExistencia_Usuario(string Valor)
        {
            try
            {
                int a = Int32.Parse(Valor);
                for (int i = 0; i < Dados_Usuario_all.Count; i++)
                {
                    if (Dados_Usuario_all[i].codigo == a)
                        return false;
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
        }


        #endregion


    }
}
