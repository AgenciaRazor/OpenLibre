using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenLibre
{
    /// <summary>
    /// classe de conexão com banco de dados para dados do usuario
    /// </summary>
    public class BD_Usuario
    {
        /// <summary>
        /// obtem dados do bando de Dados 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Usuario> GetDateFromBd()
        {
            //colletion que contera todos os dados que esta contido em Usuário
            ObservableCollection<Usuario> Dados_bd = new ObservableCollection<Usuario>();
            string st_Conexao = "server=localhost; user=funcionario; database=openlibre; port=3306; password=funcionario";
            string st_Comando = "Select Codigo_Usuario,nome,cpf,celular,estado from Usuario";
            MySqlConnection con = new MySqlConnection(st_Conexao);
            MySqlCommand comando = new MySqlCommand(st_Comando, con);
            try
            {
                con.Open();
                MySqlDataReader dados = comando.ExecuteReader();
                while (dados.Read())
                {
                    Dados_bd.Add(new Usuario((int)dados[0],(string)dados[1],(string)dados[2],(string)dados[3],(bool)dados[4]));
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(string.Format("erro code {0}", ex.ErrorCode));
            }
            finally
            {
                con.Close();
            }
            return Dados_bd;
        }
        /// <summary>
        /// Metodo Colocar As Informações dos Usuários no BD
        /// </summary>
        public void DadosParaBanco(int codigo,string nome,string cpf,string celular,bool estado)
        {
            string st_Conexao = "server=localhost; user=funcionario; database=openlibre; port=3306; password=funcionario";
            
            string st_comando = "Insert into usuario(Codigo_Usuario,nome,cpf,celular,estado) values(@Val1,@val2,@Val3,@val4,@Val5)";
            MySqlConnection con = new MySqlConnection(st_Conexao);
            MySqlCommand comando = new MySqlCommand(st_comando,con);
            try
            {
                con.Open(); // abre o banco de Dados 
                comando.Parameters.Add("@val1", MySqlDbType.Int32);
                comando.Parameters["@val1"].Value = codigo;
                comando.Parameters.Add("@val2", MySqlDbType.VarChar);
                comando.Parameters["@val2"].Value = nome;
                comando.Parameters.Add("@val3", MySqlDbType.VarChar);
                comando.Parameters["@val3"].Value = cpf;
                comando.Parameters.Add("@val4", MySqlDbType.VarChar);
                comando.Parameters["@val4"].Value = celular;
                comando.Parameters.Add("@val5", MySqlDbType.Int32);
                comando.Parameters["@val5"].Value = 1;
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally
            {
                con.Clone();
            }
        }
    }
}
