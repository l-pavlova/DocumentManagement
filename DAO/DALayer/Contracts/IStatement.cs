namespace DocManagement
{
    public interface IStatement
    {
        string ColumnName { get; set; }
        object Value { get; set; }
    }
}
