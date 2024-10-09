using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clean.Application.Contracts;
using MediatR;

namespace Clean.Application.Requests.Queries.GetAllDogs;

public class GetAllDogsQuery : IRequest<IEnumerable<DogModel>>
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, IEnumerable<DogModel>>
    {
        private readonly IDogRepository dogRepository;

        public GetAllDogsQueryHandler(IDogRepository dogRepository)
        {
            this.dogRepository = dogRepository;
        }
        
        public async Task<IEnumerable<DogModel>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            var dogs = await this.dogRepository.GetAllAsync();
            return dogs.Select(x => new DogModel
            {
                Id = x.Id,
                Name = x.Name,
                OwnerName = x.OwnerName,
            });
        }
    }
}