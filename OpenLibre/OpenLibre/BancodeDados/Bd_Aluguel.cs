using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenLibre
{
    /// <summary>
    /// 
    /// </summary>
   public class Bd_Aluguel
   {

        /// <summary>
        /// Ligação Com Banco de Dados 
        /// </summary>
        public void Alugar_bd(int codigoUsuario,int CodigoLivro)
       {

            DateTime DiaHoraAtual = DateTime.Now;
            Funcionario Func_Dados = ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Funcionario_Atual;
            DateTime data_Atual = DateTime.Now;
            DateTime Data_De_Devoulucao = data_Atual.AddDays(7); // ira conter o valor a 
            string CodigoFuncionario = Func_Dados.nome; // contem codigo do Funcionario
            string st_Conexao = "server=localhost;user=funcionario;database=openlibre;port=3306;password=funcionario";
            string st_Comando = "insert into aluguel (Codigo_Usuario,Codigo_Livro,login_Funcionario,data_devolucao) values (@val1,@val2,@val3,@Val4)";
            string st_Comando1 = "update livro set estado = 0 where Codigo =" + CodigoLivro; // update em Livros
            string st_Comando2 = "update usuario set estado = 0 where Codigo_Usuario =" + codigoUsuario; // Update em Usuario
            MySqlConnection con = new MySqlConnection(st_Conexao);
            MySqlCommand comando = new MySqlCommand(st_Comando, con);
            MySqlCommand comando1 = new MySqlCommand(st_Comando1, con);
            MySqlCommand comando2 = new MySqlCommand(st_Comando2, con);
            try
            {
                con.Open();
                comando.Parameters.Add("@val1", MySqlDbType.Int32);
                comando.Parameters["@val1"].Value = codigoUsuario;
                comando.Parameters.Add("val2", MySqlDbType.Int32);
                comando.Parameters["@val2"].Value = CodigoLivro;
                comando.Parameters.Add("@val3", MySqlDbType.VarChar);
                comando.Parameters["@Val3"].Value = CodigoFuncionario;
                comando.Parameters.Add("@val4", MySqlDbType.Date);
                comando.Parameters["@val4"].Value = Data_De_Devoulucao;
                comando.ExecuteNonQuery();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery(); 
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally // fecha o banco de Dados
            {
                con.Close();
            }
            

        }

       /// <summary>
       /// Devolução do Livro
       /// </summary>
       /// <param name="CodigoLivro"></param>
       public void Devolver_Bd(int CodigoLivro)
       {
            int Codigo_Usuario = 0;
            string st_Connection = "server=localhost;user=funcionario;database=openlibre;port=3306;password=funcionario"; // string de conexão
            string st_Comando = "select Codigo_Usuario from aluguel where Codigo_Livro =" + CodigoLivro; // comando // selecionar o codigo do Usuário  
            string st_Comando1 = "update livro set estado = 1 where Codigo ="+CodigoLivro; // comando1
            string st_Comando3 = "delete from aluguel where Codigo_Livro =" + CodigoLivro; // comando 3 de deletação
            MySqlConnection con = new MySqlConnection(st_Connection);
            MySqlCommand comando = new MySqlCommand(st_Comando,con);
            MySqlCommand comando1 = new MySqlCommand(st_Comando1, con);
            MySqlCommand comando3 = new MySqlCommand(st_Comando3, con);
            try
            {
                con.Open();
                MySqlDataReader Aluguel = comando.ExecuteReader(); // Consegue Dados do Usuário 
                while (Aluguel.Read()) // coloca a variavel dentro
                {
                    Codigo_Usuario = (int)Aluguel[0];
                }
                Aluguel.Close();
                string st_Comando2 = "update usuario set estado = 1 where Codigo_Usuario =" + Codigo_Usuario;
                MySqlCommand comando2 = new MySqlCommand(st_Comando2, con);
                comando1.ExecuteNonQuery(); // Livro esta Disponivel 
                comando2.ExecuteNonQuery(); // Usuário Está Disponviel
                comando3.ExecuteNonQuery(); // exclui dos dados do aluguel do livro

            }
            catch (MySqlException ex) // caso ocorra uma erro, é capturado uma excessão 
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally // Fecha A Conexão 
            {
                con.Close();
            }

       }
       



    }
}
