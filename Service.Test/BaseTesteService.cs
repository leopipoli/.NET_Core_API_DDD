using AutoMapper;
using CrossCutting.Mappings;

namespace Service.Test
{
    public abstract class BaseTesteService
    {
        public IMapper Mapper { get; set; }
        public BaseTesteService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(x =>
                {
                    x.AddProfile(new ModelToEntityProfile());
                    x.AddProfile(new DtoToModelProfile());
                    x.AddProfile(new EntityToDtoProfile());
                });

                return config.CreateMapper();
            }

            public void Dispose()
            {

            }
        }
    }
}