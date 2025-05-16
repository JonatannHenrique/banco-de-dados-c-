using System;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace MyBancoDeDados
{
    class Program
    {
        static void Main()
        {
            Console.Write("Diga seu Nome: ");
            string Name = Console.ReadLine();
            Console.Write("Diga sua Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());


            string strConexao = "Server=localhost;user=root;password=Jonataneronilda1Z;database=bancoteste;";

            try
            {
                using (var conexao = new MySqlConnection(strConexao))
                {
                    conexao.Open();

                    string sql = @"INSERT INTO pessoas (nome, idade)
                                   VALUES (@nome, @idade);";

                    using (var cmd = new MySqlCommand(sql, conexao))
                    {

                        cmd.Parameters.AddWithValue("@nome", Name);
                        cmd.Parameters.AddWithValue("@idade", idade);

                        int linhas = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{linhas} registro(s) inserido(s) com sucesso.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir no banco: " + ex.Message);
            }

        }
    }
}
