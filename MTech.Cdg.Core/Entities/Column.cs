namespace MTech.Cdg.Core
{
    public class Column : ObjectBase
    {
        public Table Table { get; set; }
        public bool IsPk { get; set; }
        public bool IsUnique { get; set; }
        public bool IsIdentity { get; set; }

        public int size { get; set; }

        public Typer typed { get; set; }
        public DataType datatype { get; set; }
    }
}
