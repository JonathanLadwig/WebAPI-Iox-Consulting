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
            int userID;
            if (Int32.TryParse(query.varstring, out userID))
            {

            }
            else{
                userID = -1;
            }
            IPagedList<Vehicle> vehicles = _context.Vehicles.Where(a => a.Vin.Contains(query.varstring) || a.LicenseNumber.Contains(query.varstring) || a.Model.Contains(query.varstring) || a.Color == query.varstring || a.RegistrationPlate.Contains(query.varstring) || a.AccountId == userID).ToPagedList<Vehicle>(1, 10);
            //IPagedList<Vehicle> vehicles = vehicle.ToPagedList<Vehicle>(5,5);
            return (PagedList<Vehicle>)vehicles; 
        }
    }
}
