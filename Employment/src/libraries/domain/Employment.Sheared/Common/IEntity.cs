namespace Employment.Sheared.Common;

public interface IEntity<T>where T :IEquatable<T>
{
}
public interface IEntity : IEntity<int> { }
