namespace FilterExample1.Services
{
    public class TransactionLogService
    {
        private static List<string> l1 = new List<string>();

        public void LogTransaction(string msg)
        {
            l1.Add(DateTime.Now.ToString() + ":" + msg);
        }

        public IEnumerable<string> GetTransactions()
        {
            return l1;
        }
    }
}
