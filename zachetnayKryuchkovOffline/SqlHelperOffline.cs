using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayKryuchkovOffline
{

    public class SqlHelperOffline
    {
        protected SqlConnection connection = new SqlConnection(Properties.Settings.Default.SKLADConnectionString);
        protected SqlCommand command = new SqlCommand();
        protected SqlDataReader reader;

  

        private void close_reader()
        {
            connection.Close();
            if (reader != null)
            {
                reader.Close();
            }

        }

        private void IntoDataBase(string message)
        {
            try
            {
                connection.Open();
                int n = command.ExecuteNonQuery();
                MessageBox.Show(message);
            }
            catch (SqlException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                close_reader();
            }
        }

        private SqlDataReader readDataFromDB(string commandText)
        {
            connection.Open();
            command.CommandText = commandText;
            command.Connection = connection;
            reader = command.ExecuteReader();
            return reader;
        }


        public List<T> SelectReport<T>(string sqlQuerry) where T:ClassElement, new()
        {
            SqlDataReader reader = readDataFromDB(sqlQuerry);
            List<T> Datas = new List<T>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Datas.Add(new T());
                    Datas[Datas.Count - 1].AddParametrs(reader);
                }
            }

            this.close_reader();
            return Datas;
        }
        

        public List<T> Select<T>(string table) where T:ClassElement, new()
        {
            string sqlQuerry = string.Format("select * from {0}", table);
            SqlDataReader reader = readDataFromDB(sqlQuerry);
            List<T> Datas = new List<T>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Datas.Add(new T());
                    Datas[Datas.Count - 1].AddParametrs(reader);
                }
            }

            this.close_reader();
            return Datas;
        }

        public void Insert(string tableName, params(string name, SqlDbType sqlType, object newElem)[] elements )
        {
            command.Parameters.Clear();
            
            string sqlQuerry = string.Format("insert into {0} values (", tableName);
            foreach(var (name, sqlType, newElem) in elements)
            {
                sqlQuerry += "@" + name + ", ";
            }
            sqlQuerry = sqlQuerry.Substring(0, sqlQuerry.Length - 2) + ")";

            command.CommandText = sqlQuerry;
            command.Connection = connection;

            foreach (var (name, sqlType, newElem) in elements)
            {
                command.Parameters.Add("@" + name, sqlType);
                command.Parameters["@" + name].Value = newElem;
            }
            
            //
            IntoDataBase("Запись добавлена!!!");
        }

        public void Update(string sqlQuerry, params (string name, SqlDbType sqlType, object newElem)[] elements)
        {
            command.Parameters.Clear();
            command.CommandText = sqlQuerry;
            command.Connection = connection;
            foreach(var (name, sqlType, newElem) in elements)
            {
                command.Parameters.Add("@" + name, sqlType);
                command.Parameters["@" + name].Value = newElem; 
            }

            IntoDataBase("Изменение выполнено!!!");
        }


        public void Delete(string tableName, string pk, object pknumber)
        {
            string sqlQuerry = string.Format("delete from {0} where {1}=@{2}", tableName, pk, pk);
            command.Parameters.Clear();
            command.CommandText = sqlQuerry;
            command.Connection = connection;
            command.Parameters.AddWithValue("@"+pk, pknumber);

            IntoDataBase("Удаление выполнено!!!");
        }

        public void DeleteFromSklad(string data, int stoim, int kt)
        {
            string sqlQuerry = string.Format("delete from sklad where datap='{0}' and stoim={1} and kt = {2}", data, stoim, kt);
            command.Parameters.Clear();
            command.CommandText = sqlQuerry;
            command.Connection = connection;
            IntoDataBase("Удаление выполнено!!!");
        }


    }
}
