using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAPI_Test.Model;

namespace WebAPI_Test.Queries
{
    public class GetVehicleListQuery : IRequest<List<Vehicle>>
    {
        public int Id { get; set; }
        
    }
}
