using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;

public class ObjectIdRouteConstraint : IRouteConstraint
{
    public bool Match(HttpContext httpContext,
                      IRouter route,
                      string routeKey,
                      RouteValueDictionary values,
                      RouteDirection routeDirection)
    {
        // Verifica si el valor del parámetro es un ObjectId válido
        if (values.TryGetValue(routeKey, out var value) && value is string strValue)
        {
            return ObjectId.TryParse(strValue, out _);
        }
        return false;
    }
}
