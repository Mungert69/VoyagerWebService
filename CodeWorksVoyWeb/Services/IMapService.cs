using System.Collections.Generic;

public interface IMapService
{
    List<PlaceState> selectHops(ISessionObject sessionObj);
}