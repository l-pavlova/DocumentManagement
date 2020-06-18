using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace DocManagement
{
    public class Adapter<T> : IAdapter<T> where T : class, new()
    {
        private SqlConnection con = ConnectionFactory.GetDbConnection();
        private DataTable dt;
        private StringBuilder select;
        private StringBuilder add;
        private StringBuilder delete;
        private StringBuilder update;

        protected static Dictionary<string, string> Mappings { get; private set; }
        private string CreateCondition(ICondition condition)
        {

            switch (condition.Op)
            {
                case Operator.Less: return $"{condition.ColumnName} <";
                case Operator.LessOrEqual: return $"{condition.ColumnName} <=";
                case Operator.Greater: return $"{condition.ColumnName} >";
                case Operator.GreaterOrEqual: return $"{condition.ColumnName} >=";
                case Operator.Equal: return $"{condition.ColumnName} =";
                case Operator.NotEqual: return $"{condition.ColumnName} <>";
                case Operator.Unknown: return String.Empty;

                default: throw new InvalidOperationException($"Not recognised operation {condition.Op}");
            }
        }
        private string CreateStatement(IStatement statement)
        {
            return $"{statement.ColumnName} =";
        }
        public Adapter()
        {

        }
        public Adapter(Dictionary<string, string> maps)
        {
            Mappings = maps;
        }
        public T GetItem(string tablename, Guid g)
        {
            List<Condition> conditions = new List<Condition>();

            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = typeof(T).GetProperties();
            }
            foreach (var info in propertyInfos)
            {
                IDAttribute idAttr = (IDAttribute)Attribute.GetCustomAttribute(info, typeof(IDAttribute));
                if (idAttr != null)
                {
                    conditions.Add(new Condition(Operator.Equal, g, idAttr.Name));
                }

            }
            return Select(tablename, null, conditions).DataTableToList<T>().FirstOrDefault<T>();

        }
        public List<T> GetItem(string tablename, DateTime date)
        {
            List<Condition> conditions = new List<Condition>();

            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = typeof(T).GetProperties();
            }
            foreach (var info in propertyInfos)
            {
                DateAttribute dateAttr = (DateAttribute)Attribute.GetCustomAttribute(info, typeof(DateAttribute));
                if (dateAttr != null)
                {
                    conditions.Add(new Condition(Operator.Less, date, dateAttr.Name));
                }

            }
            return Select(tablename, null, conditions).DataTableToList<T>();

        }
        public virtual List<T> GetItem(string tablename, MailAddress address)
        {
            List<Condition> conditions = new List<Condition>();

            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = typeof(MailAddress).GetProperties();
            }

            foreach (var info in propertyInfos)
            {
                var value = info.GetValue(address) ?? "(null)";
                if (Mappings.ContainsKey(info.Name))
                {
                    conditions.Add(new Condition(Operator.Equal, value, Mappings[info.Name]));
                }

            }

            return Select(tablename, null, conditions).DataTableToList<T>();
        }
        public List<T> GetItem(string tablename, string Id)
        {
            List<Condition> conditions = new List<Condition>();

            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = typeof(T).GetProperties();
            }
            foreach (var info in propertyInfos)
            {
                UserAttribute userAttr = (UserAttribute)Attribute.GetCustomAttribute(info, typeof(UserAttribute));
                if (userAttr != null)
                {
                    conditions.Add(new Condition(Operator.Equal, Id, userAttr.Name));
                }

            }

            return Select(tablename, null, conditions).DataTableToList<T>();
        }
        public List<T> GetItems(string table, IEnumerable<string> columns = null, IEnumerable<Condition> conditions = null)
        {

            //todo: create abstract query put impls in facade use in selects 
            return Select(table, columns, conditions).DataTableToList<T>();
        }
        public DataTable Select(string table, IEnumerable<string> columns = null, IEnumerable<Condition> conditions = null)
        {
            select = new StringBuilder("SELECT ");
            SqlDataAdapter adapter;
            if (columns != null)
            {
                select.Append(string.Join(", ", columns));
            }
            select.Append($"*FROM {table}");
            SqlCommand command = new SqlCommand();
            var conditionsList = new List<string>();
            if (conditions != null)
            {
                select.Append(" WHERE ");
                foreach (var item in conditions)
                {
                    var paramName = new ParamNameGenerator().GenerateParamName(item.ColumnName);
                    string cond = CreateCondition(item) + paramName;
                    conditionsList.Add(cond);
                    command.Parameters.AddWithValue(paramName, item.Value);
                }
                select.Append(string.Join(" AND ", conditionsList));

            }
            command.CommandText = select.ToString();
            command.Connection = con;

            adapter = new SqlDataAdapter(command);
            dt = new DataTable();
            try
            {
                con.Open();
                adapter.Fill(dt);
                adapter.Dispose();
            }
            catch (SqlException)
            {
                throw new ArgumentNullException();
            }
            catch (InvalidOperationException)
            {
                throw new TooManyConnectionsOpenedException();
            }
            finally
            {
                command?.Dispose();
                con?.Close();
            }
            return dt;
        }

        public virtual void InsertItems(string table, IEnumerable<T> items)
        {

            List<Condition> conditions = new List<Condition>();
            foreach (var item in items)
            {
                PropertyInfo[] propertyInfos = null;

                if (propertyInfos == null)
                {
                    propertyInfos = item.GetType().GetProperties();
                }
                foreach (var info in propertyInfos)
                {
                    var value = info.GetValue(item) ?? "(null)";

                    if (Mappings.TryGetValue(info.Name, out string columnName))
                    {
                        conditions.Add(new Condition(Operator.Equal, value, columnName));
                    }
                }
                Insert(table, null, conditions);
                conditions.Clear();
            }
        }
        public void Insert(string table, IEnumerable<string> columns = null, IEnumerable<IStatement> conditions = null)
        {
            add = new StringBuilder("INSERT INTO ");
            add.Append($"{table} ");
            if (columns != null)
            {
                add.Append(string.Join(", ", columns));
            }
            SqlCommand command = new SqlCommand();
            if (conditions != null)
            {
                add.Append("(");
                var conditionsList = new List<string>();
                var paramList = new List<string>();
                foreach (var item in conditions)
                {
                    var paramName = new ParamNameGenerator().GenerateParamName(item.ColumnName);
                    conditionsList.Add(item.ColumnName);
                    command.Parameters.AddWithValue(paramName, item.Value);
                    paramList.Add(paramName);
                }
                add.Append(string.Join(",", conditionsList)).Append(" ) VALUES( ").Append(string.Join(",", paramList)).Append(")");
            }
            command.CommandText = add.ToString();
            command.Connection = con;
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                command?.Dispose();
                con?.Close();
            }
        }

        public void DeleteItem(string table, Guid guid)
        {
            List<Condition> conditions = new List<Condition>();
            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = typeof(T).GetProperties();
            }
            foreach (var info in propertyInfos)
            {
                var value = guid;
                IDAttribute idAttr = (IDAttribute)Attribute.GetCustomAttribute(info, typeof(IDAttribute));
                if (idAttr != null)
                {
                    conditions.Add(new Condition(Operator.Equal, value, idAttr.Name));
                }
            }
            Delete(table, null, conditions);
        }
        public void Delete(string table, IEnumerable<string> columns = null, IEnumerable<Condition> conditions = null)
        {
            delete = new StringBuilder("DELETE FROM ");
            SqlCommand command = new SqlCommand();
            delete.Append($"{table} ");
            if (conditions != null)
            {
                delete.Append("WHERE ");
            }
            foreach (var item in conditions)
            {
                var paramName = new ParamNameGenerator().GenerateParamName(item.ColumnName);
                delete.Append(CreateCondition(item) + paramName);
                command.Parameters.AddWithValue(paramName, item.Value);
            }
            command.CommandText = delete.ToString();
            command.Connection = con;
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                con?.Close();
            }
        }

        public virtual void UpdateItem(string table, T item)
        {

            List<Condition> conditions = new List<Condition>();
            List<Statement> columns = new List<Statement>();
            PropertyInfo[] propertyInfos = null;

            if (propertyInfos == null)
            {
                propertyInfos = item.GetType().GetProperties();
            }
            foreach (var info in propertyInfos)
            {
                var value = info.GetValue(item) ?? "(null)";
                if (Mappings.ContainsKey(info.Name))
                {
                    columns.Add(new Statement(value, Mappings[info.Name]));
                }
                IDAttribute idAttr = (IDAttribute)Attribute.GetCustomAttribute(info, typeof(IDAttribute));
                if (idAttr != null)
                {
                    conditions.Add(new Condition(Operator.Equal, value, idAttr.Name));
                }

            }
            Update(table, columns, conditions);
        }
        public void Update(string table, IEnumerable<IStatement> columns = null, IEnumerable<Condition> conditions = null)
        {
            update = new StringBuilder("UPDATE ");
            var paramGen = new ParamNameGenerator();
            SqlCommand command = new SqlCommand();
            update.Append($"{table} ");
            var updateColsList = new List<string>();
            if (columns != null)
            {
                update.Append("SET ");
                foreach (var item in columns)
                {
                    var paramName = paramGen.GenerateParamName(item.ColumnName);
                    string cond = CreateStatement(item) + paramName;
                    updateColsList.Add(cond);
                    command.Parameters.AddWithValue(paramName, item.Value);
                }
                update.Append(string.Join(" , ", updateColsList));
            }
            if (conditions != null && conditions.Any())
            {
                update.Append(" WHERE ");
                var paramsList = new List<string>();
                foreach (var item in conditions)
                {

                    var paramName = paramGen.GenerateParamName(item.ColumnName);
                    string cond = CreateCondition(item) + paramName;
                    paramsList.Add(cond);
                    command.Parameters.AddWithValue(paramName, item.Value);
                }
                update.Append(string.Join(" AND ", paramsList));
            }

            command.CommandText = update.ToString();
            command.Connection = con;
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();

                dataAdapter.UpdateCommand = command;
                con.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();
            }
            finally
            {
                command?.Dispose();
                con?.Close();
            }

        }


    }
}
