namespace DocManagement
{
    public class Statement : IStatement
    {

        public string ColumnName { get; set; }
        public object Value { get; set; }

        public Statement(object value, string colName = "")
        {
            ColumnName = colName;
            Value = value;
        }
    }
}
