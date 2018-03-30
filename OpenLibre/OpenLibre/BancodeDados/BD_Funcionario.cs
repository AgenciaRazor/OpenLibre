using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace OpenLibre
{
    /// <summary>
    /// Classe para ligação com Banco de Dados 
    /// </summary>
    public class BD_Funcionario
    {

        #region Ligações 

        /// <summary>
        /// metodo para ligação 
        /// </summary>
        public void Dados(string nome, string usuario, string senha, string cpf)
        {
            string Conexao = "server=localhost;user=funcionario;database=openlibre;port=3306;password=funcionario";
            string Comando = "Insert into Funcionario(nome_login,nome_funcionario,senha,cpf_funcionario) values (@val1,@val2,@val3,@val4)";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlCommand comando = new MySqlCommand(Comando, con);
            try
            {
                //Insere dados dentro do bando de Dados Open libre
                con.Open();
                comando.Parameters.Add("@val1", MySqlDbType.VarChar);
                comando.Parameters["@val1"].Value = usuario;
                comando.Parameters.Add("@val2", MySqlDbType.VarChar);
                comando.Parameters["@val2"].Value = nome;
                comando.Parameters.Add("@val3", MySqlDbType.VarChar);
                comando.Parameters["@val3"].Value = senha;
                comando.Parameters.Add("@val4", MySqlDbType.VarChar);
                comando.Parameters["@val4"].Value = cpf;
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }

            finally 
            {
                // Fecha Banco de Dados
                con.Close();
            }
        }
        /// <summary>
        /// Estabelece uma Ligação com Banco de Dados e caso logim e senha estejam corretos, o funcionario Loga No Sistema 
        /// </summary>
        public bool Conexao(string nome,string senha)
        {
            bool teste = false;
            string Conexao = "server=localhost;user=funcionario; database=openlibre; port=3306; password=funcionario";
            string Comando = "select * from funcionario";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlCommand comando = new MySqlCommand(Comando, con);
            try
            {
                con.Open();// tenta abrir
                MySqlDataReader dados = comando.ExecuteReader();
                while (dados.Read())
                {
                    // testa se a senha e o password 
                    if ((string)dados[0] == nome && (string)dados[2] == senha)
                    {
                        ((WindowsViewModel)((MainWindow)Application.Current.MainWindow).DataContext).Funcionario_Atual = new Funcionario((string)dados[0]);
                        teste = true;
                        break;
                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally
            {
                con.Close();
            }
           return teste;
        }
        /// <summary>
        /// Verifica se o nome de Usuário já existe 
        /// </summary>
        /// <param name="User">Nome de Usuario pra teste</param>
        /// <returns></returns>
        public bool Verificao_Usuario(string User)
        {

            bool teste = false;
            string Conexao = "server=localhost;user=root; database=openlibre; port=3306; password=root";
            string Comando = "select * from funcionario";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlCommand comando = new MySqlCommand(Comando, con);
            try
            {
                con.Open();// tenta abrir
                MySqlDataReader dados = comando.ExecuteReader();
                while (dados.Read())
                {
                    // se for True Indica
                    if ((string)dados[0] == User)
                    {
                        teste = true;
                        break;
                    }
                }
            }
            // Captura Excessãoes de ligação com banco de Dados 
            catch (MySqlException ex)
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally
            {
                con.Close();
            }
            return teste; 

        }
        #endregion

    }
}
