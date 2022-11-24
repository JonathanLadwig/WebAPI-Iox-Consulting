using MediatR;
using WebAPI_Test.Model;
using WebAPI_Test.Queries;

namespace WebAPI_Test.Handlers
{
    public class GetVehicleListHandler : IRequestHandler<GetVehicleListQuery, List<Vehicle>>
    {
        private readonly IoxDbContext _context;
        public GetVehicleListHandler(IoxDbContext context)
        {
            _context= context;
        }

        public async Task<List<Vehicle>> Handle(GetVehicleListQuery query, CancellationToken cancellationToken)
        {
            //Should be a paged list
            List<Vehicle> vehicle = (List<Vehicle>)_context.Vehicles.Where(a => a.Vin == query.variable);
            if (vehicle == null)
            {
                return null;
            }

            return vehicle; 
        }
    }
}
