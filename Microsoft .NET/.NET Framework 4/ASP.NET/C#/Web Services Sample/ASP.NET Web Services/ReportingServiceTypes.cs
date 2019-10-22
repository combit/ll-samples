namespace combit.Services
{
    public sealed class Error
    {
        internal Error()
        {
            Code = 0;
        }

        internal Error(string newDescription)
            : this(-1, newDescription)
        {
        }

        internal Error(int newCode, string newDescription)
        {
            Code = newCode;
            Description = newDescription;
        }

        public int Code { get; set; }
        public string Description { get; set; }
        public bool Succeeded { get { return (Code == 0); } }
    }

    public sealed class Response<T>
    {
        internal Response()
        {
            Status = new Error();
        }

        internal Response(T value)
        {
            Status = new Error();
            Value = value;
        }

        internal Response(Error status)
        {
            Status = status;
        }

        public Error Status { get; set; }
        public T Value { get; set; }
        public string RequesterID { get; set; }
    }

    public sealed class Response
    {
        internal Response()
        {
            Status = new Error();
        }

        internal Response(Error status)
        {
            Status = status;
        }

        public Error Status { get; set; }
    }

    public sealed class DataSource
    {
        internal DataSource(string newId, string newName, string newDescripton, string newImage)
        {
            Id = newId;
            Name = newName;
            Description = newDescripton;
            Image = newImage;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public sealed class Report
    {
        internal Report(string newDatasource, string newName, string newDescripton, string newImage)
        {
            Datasource = newDatasource;
            Name = newName;
            Description = newDescripton;
            Image = newImage;
        }

        public string Datasource { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class ReportFormat
    {
        internal ReportFormat(string newId, string newDescripton, string newImage)
        {
            Id = newId;
            Description = newDescripton;
            Image = newImage;
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}