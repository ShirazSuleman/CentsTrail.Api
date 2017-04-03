using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CentsTrail.Api.Filters
{
  public class AddAuthorizationHeader : IOperationFilter
  {
    public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
    {
      if (operation == null)
        return;

      if (operation.parameters == null)
        operation.parameters = new List<Parameter>();

      var parameter = new Parameter
      {
        description = "The authorization token",
        @in = "header",
        name = "Authorization",
        required = true,
        type = "string"
      };

      if (apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
        parameter.required = false;

      operation.parameters.Add(parameter);
    }
  }
}