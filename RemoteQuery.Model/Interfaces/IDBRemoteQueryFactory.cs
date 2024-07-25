namespace RemoteQuery.Model
{
    public interface IDBRemoteQueryFactory
    {
        IConnectionData CreateConnectionData();
    }
}