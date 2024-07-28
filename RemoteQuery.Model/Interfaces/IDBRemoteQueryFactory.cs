namespace RemoteQuery.Model
{
    public interface IDBRemoteQueryFactory
    {
        IConnectionData CreateConnectionData();
        IDatabaseContext GetDbContext(Model.RemoteQuery query);
    }
}