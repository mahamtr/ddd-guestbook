using CleanArchitecture.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Events.Rubros
{
    public class GetAllRubros : IRequest<IEnumerable<RubroDTO>>
    {
    }
}
