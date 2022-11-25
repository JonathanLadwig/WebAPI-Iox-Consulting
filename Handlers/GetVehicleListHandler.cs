using MediatR;
using PagedList;
using WebAPI_Test.Model;
using WebAPI_Test.Queries;

namespace WebAPI_Test.Handlers
{
    public class GetVehicleListHandler : IRequestHandler<GetVehicleListQuery, PagedList<Vehicle>>
    {
        private readonly IoxDbContext _context;
        public GetVehicleListHandler(IoxDbContext context)
        {
            _context= context;
        }

        public async Task<PagedList<Vehicle>> Handle(GetVehicleListQuery query, CancellationToken cancellationToken)
        {
            PagedList<Vehicle> vehicle = (PagedList<Vehicle>) _context.Vehicles.Where(a => a.Vin.Contains(query.varstring) || a.LicenseNumber.Contains(query.varstring) || a.Model.Contains(query.varstring) || a.Color == query.varstring || a.RegistrationPlate.Contains(query.varstring));
            return vehicle; 
        }
    }
}
