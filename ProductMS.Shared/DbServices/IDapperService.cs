namespace ProductMS.Shared.DbServices;
public interface IDapperService
{
	int Execute(string query, object? param = null);
	List<M> Query<M>(string query, object? param = null);
	M QueryFirstOrDefault<M>(string query, object? param = null);
}