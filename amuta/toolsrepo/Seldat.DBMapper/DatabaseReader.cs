namespace Seldat.DBMapper
{
    internal class DatabaseReader
    {
        private string connectionString;
        private string providername;

        public DatabaseReader(string connectionString, string providername)
        {
            this.connectionString = connectionString;
            this.providername = providername;
        }
    }
}