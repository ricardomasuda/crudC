using CrudFuncionario.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudFuncionario.Dados
{
    public class FuncionarioRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado;";
            _con = new SqlConnection(constr);
            _con.Open();
        }

        public bool AdicionarFuncionario(Funcionario funcionario)
        {
            Connection();

            using (SqlCommand comand = new SqlCommand("INSERT INTO Funcionario (Nome, Idade) VALUES(@Nome,@Idade)", _con))
            {
                comand.Parameters.AddWithValue("@Nome", funcionario.Nome);
                comand.Parameters.AddWithValue("@Idade", Convert.ToInt32(funcionario.Idade));
                var executou = comand.ExecuteNonQuery() >= 1;

                _con.Close();

                return executou;

            }
        }

        public List<Funcionario> ObterFuncionarios()
        {

            Connection();
            List<Funcionario> listFuncionarios = new List<Funcionario>();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Funcionario", _con))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario()
                    {
                        FuncionarioId = Convert.ToInt32(reader["FuncionarioId"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Idade = Convert.ToUInt32(reader["Idade"])
                    };
                    listFuncionarios.Add(funcionario);
                }
                _con.Close();

            }
            return listFuncionarios;

        }

        public bool AtualizarFuncionario(Funcionario funcionario)
        {
            Connection();

            using (SqlCommand command = new SqlCommand("UPDATE Funcionario SET Nome=@Nome, Idade=@Idade WHERE FuncionarioId=@FuncionarioId", _con))
            {
                command.Parameters.AddWithValue("@Nome", funcionario.Nome);
                command.Parameters.AddWithValue("@Idade", Convert.ToInt32(funcionario.Idade));
                command.Parameters.AddWithValue("@FuncionarioId", funcionario.FuncionarioId);

                var executou = command.ExecuteNonQuery() >= 1;

                _con.Close();

                return executou;
            }
        }


        public bool ExcluiFuncionario(int id)
        {
            Connection();
            using (SqlCommand command = new SqlCommand("DELETE FROM Dependente WHERE FuncionarioId=@FuncionarioId", _con))
            {
                command.Parameters.AddWithValue("@FuncionarioId", id);

                command.ExecuteNonQuery();
            }

            using (SqlCommand command = new SqlCommand("DELETE FROM Funcionario WHERE FuncionarioId=@FuncionarioId", _con))
            {

                command.Parameters.AddWithValue("@FuncionarioId", id);

                var executou = command.ExecuteNonQuery() >= 1;

                _con.Close();

                return executou;
            }
        }
    }
}