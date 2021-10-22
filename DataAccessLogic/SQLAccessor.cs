namespace DataAccessLogic
{
    public class SQLAccessor : ISQLAccessor
    {
        private string _connectionString;
        private string _providerName;

        public SQLAccessor(string connectionString, string providerName)
        {
            _connectionString = connectionString;
        }

        public void AccessSQL()
        {
            throw new System.NotImplementedException();
        }
    }
}