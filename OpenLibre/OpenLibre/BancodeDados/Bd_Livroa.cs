using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenLibre
{
    /// <summary>
    /// 
    /// </summary>
    public class Bd_Livros
    {
        /// <summary>
        /// Metodo para 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Livros> Db_GetData()
        {
            //Coleção para Conter os Dados
            ObservableCollection<Livros> ob_Dados = new ObservableCollection<Livros>();
            // string de conexão
            string Conexao = "server=localhost;user=funcionario; database=openlibre; port=3306; password=funcionario";
            //string de comando 
            string st_comando = "select Codigo,nome,Nome_Autor,isbn,Nome_estado from livro join autor on livro.codigo_autor = autor.Codigo_Autor join estado on estado.Codigo_Estado = livro.estado";
            MySqlConnection con = new MySqlConnection(Conexao);
            MySqlCommand Comando = new MySqlCommand(st_comando,con);
            try
            {
                con.Open(); //tenta abrir uma conexão com bd
                MySqlDataReader dados = Comando.ExecuteReader(); // coloca os dados do bd em um reador
                while (dados.Read())
                {
                    // coloca os dados do banco de dados dentro do array
                    ob_Dados.Add(new Livros((int)dados[0], (string)dados[1], (string)dados[2], (string)dados[3], (string)dados[4])); 
                  
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally
            {
                con.Close(); // fecha a conexão
            }
            return ob_Dados;
        }

        /// <summary>
        /// Comando que adiciona Dados no 
        /// </summary>
        public void Db_SetDada(int codigo,string Nome,string Autor,string isbn,int estado)
        {
            string st_conexao = "server = localhost; user = funcionario; database = openlibre; port = 3306; password = funcionario";
            string st_Comando1 = "Insert into autor(Codigo_Autor,Nome_Autor) values(@val1,@val2)";
            string st_comando2 = "Insert into livro(Codigo,nome,isbn,codigo_autor,estado) values(@val1,@val2,@val3,@val4,@val5)";
            MySqlConnection con = new MySqlConnection(st_conexao);
            MySqlCommand Comando1 = new MySqlCommand(st_Comando1, con);
            MySqlCommand comando2 = new MySqlCommand(st_comando2, con);
            try
            {
                con.Open(); // abre o banco de dados

                #region Autor
                //comando para o autor
                Comando1.Parameters.Add("@val1", MySqlDbType.Int32);
                Comando1.Parameters["@val1"].Value = codigo;
                Comando1.Parameters.Add("@val2", MySqlDbType.VarChar);
                Comando1.Parameters["@val2"].Value = Autor;
                Comando1.ExecuteNonQuery(); // executa o comando no BD..
                #endregion
                //Comando para o livro
                #region comando para inserir dados no banco
                comando2.Parameters.Add("@val1", MySqlDbType.Int32);
                comando2.Parameters["@val1"].Value = codigo;
                comando2.Parameters.Add("@val2", MySqlDbType.VarChar);
                comando2.Parameters["@val2"].Value = Nome;

                comando2.Parameters.Add("@val3", MySqlDbType.Int64);
                comando2.Parameters["@val3"].Value = isbn;
                comando2.Parameters.Add("@val4", MySqlDbType.Int32);
                comando2.Parameters["@val4"].Value = codigo;
                comando2.Parameters.Add("@val5", MySqlDbType.Int32);
                comando2.Parameters["@val5"].Value = estado;
                comando2.ExecuteNonQuery();
                    #endregion         

            }
            catch (MySqlException ex)
            {
                //Fecha O banco
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally
            {
                con.Close();
            }


        }

        /// <summary>
        /// Deleta o livro é o autor 
        /// </summary>
        /// <param name="codigo"></param>
        public void Db_DeleteDate(int codigo)
        {
            string st_conexao = "server = localhost; user = funcionario; database = openlibre; port = 3306; password = funcionario";
            string st_comando1 = "delete from livro where Codigo =" + codigo;
            string st_comando2 = "delete from autor where Codigo_Autor =" + codigo;
            MySqlConnection con = new MySqlConnection(st_conexao);
            MySqlCommand comando1 = new MySqlCommand(st_comando1, con);
            MySqlCommand comando2 = new MySqlCommand(st_comando2, con);
            try
            {
                con.Open();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Sql Serve Eroo# " + ex.Number + ": " + ex.Message, GetType().ToString());
            }
            finally
            {
                con.Close();
            }



        }



    }
}
