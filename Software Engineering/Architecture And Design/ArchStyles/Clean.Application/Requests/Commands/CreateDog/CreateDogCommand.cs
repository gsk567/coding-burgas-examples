using System;
using System.Threading;
using System.Threading.Tasks;
using Clean.Application.Contracts;
using Clean.Domain;
using MediatR;

namespace Clean.Application.Requests.Commands.CreateDog;

public class CreateDogCommand : IRequest<Guid>
{
    public string Name { get; set; }

    public string OwnerName { get; set; }
    
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Guid>
    {
        private readonly IDogRepository dogRepository;

        public CreateDogCommandHandler(IDogRepository dogRepository)
        {
            this.dogRepository = dogRepository;
        }
        
        public async Task<Guid> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            return await this.dogRepository.CreateAsync(new Dog
            {
                Name = request.Name,
                OwnerName = request.OwnerName,
            });
        }
    }
}