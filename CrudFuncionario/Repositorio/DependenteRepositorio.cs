using CrudFuncionario.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudFuncionario.Dados
{
    public class DependenteRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado;";
            _con = new SqlConnection(constr);
            _con.Open();
        }

        public bool AdicionarDependente(Dependente dependente)
        {
            Connection();

            using(SqlCommand comand = new SqlCommand("INSERT INTO Dependente (FuncionarioId, Nome) VALUES(@FuncionarioId,@Nome)", _con))
            {
                comand.Parameters.AddWithValue("@FuncionarioId", dependente.FuncionarioId);
                comand.Parameters.AddWithValue("@Nome", dependente.Nome);
                var executou =  comand.ExecuteNonQuery() >= 1;

                _con.Close();

                return executou;

            }
        }

        public List<Dependente> ObterDependentes(int id)
        {

            Connection();
            List<Dependente> listDependentes = new List<Dependente>();

            using(SqlCommand command = new SqlCommand("SELECT * FROM Dependente WHERE FuncionarioId=@funcionarioId", _con))
            {
                command.Parameters.AddWithValue("@funcionarioId", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Dependente dependente = new Dependente()
                    {
                        DependenteId = Convert.ToInt32(reader["DependenteId"]),
                        FuncionarioId = Convert.ToInt32(reader["FuncionarioId"]),
                        Nome = Convert.ToString(reader["Nome"])
                    };
                    listDependentes.Add(dependente);
                }
                _con.Close();

            }
            return listDependentes;
        }

        public bool AtualizarDependente(Dependente dependente)
        {
            Connection();

            using (SqlCommand command = new SqlCommand("UPDATE Dependente SET Nome=@Nome WHERE DependenteId=@DependenteId", _con))
            {
                command.Parameters.AddWithValue("@Nome", dependente.Nome);
                command.Parameters.AddWithValue("@DependenteId", dependente.DependenteId);

                var executou = command.ExecuteNonQuery() >= 1;

                _con.Close();

                return executou;
            }
        }


        public bool ExcluiDependente(int id)
        {
            Connection();

            using (SqlCommand command = new SqlCommand("DELETE FROM Dependente WHERE DependenteId=@DependenteId", _con))
            {
                command.Parameters.AddWithValue("@DependenteId", id);

                var executou = command.ExecuteNonQuery() >= 1;

                _con.Close();

                return executou;
            }
        }
    }
}