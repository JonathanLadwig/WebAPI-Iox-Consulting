﻿using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAPI_Test.Model;

namespace WebAPI_Test.Queries
{
    public record GetVehicleListQuery(string varstring) : IRequest<List<Vehicle>>;
}
