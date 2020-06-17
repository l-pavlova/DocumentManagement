namespace DocManagement
{
    public enum Operator
    {
        Unknown,
        Less,
        LessOrEqual,
        Greater,
        GreaterOrEqual,
        Equal,
        NotEqual

    }

    public interface ICondition : IStatement
    {
        Operator Op { get; set; }

    }
}
