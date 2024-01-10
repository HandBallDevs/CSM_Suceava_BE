using AutoMapper;
using CSU_Suceava_BE.Application.Interfaces;
using CSU_Suceava_BE.Application.Models.Utilizator;
using CSU_Suceava_BE.Infrastructure.Interfaces;

namespace CSU_Suceava_BE.Application.Services
{
    public class UtilizatorService : IUtilizatorService
    {
        private readonly IUtilizatorRepository utilizatorRepository;
        private readonly IJwtUtils jwtUtils;
        private readonly IMapper mapper;

        public UtilizatorService(IUtilizatorRepository utilizatorRepository, IJwtUtils jwtUtils, IMapper mapper)
        {
            this.utilizatorRepository = utilizatorRepository;
            this.jwtUtils = jwtUtils;
            this.mapper = mapper;
        }

        public async Task<UtilizatorResponseDto> GetUtilizatorByIdAsync(Guid id)
        {
            var utilizator = await utilizatorRepository.GetUtilizatorByIdAsync(id);

            return mapper.Map<UtilizatorResponseDto>(utilizator);
        }

        public async Task<string> LoginAsync(AuthenticationDto authentication)
        {
            var user = await utilizatorRepository.GetUtilizatorByEmailAsync(authentication.Email);
            if (user == null)
            {
                throw new Exception("Utilizatorul nu exista");
            }
            if (user.Parola != authentication.Password)
            {
                throw new Exception("Parola gresita");
            }

            return jwtUtils.GenerateToken(user);
        }
    }
}
