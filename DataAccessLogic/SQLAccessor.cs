namespace DataAccessLogic
{
    public class SQLAccessor : ISQLAccessor
    {
        private string _connectionString;
        private string _providerName;

        public SQLAccessor(string connectionString, string providerName)
        {
            _connectionString = connectionString;
            _providerName = providerName;
        }

        public void AccessSQL()
        {
            throw new System.NotImplementedException();
            
        }
    }
}