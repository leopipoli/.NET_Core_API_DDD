﻿using API;
using AutoMapper;
using CrossCutting.Mappings;
using Data.Context;
using Domain.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient client { get; private set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();
            client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "leonardo.pipoli48@gmail.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}login", client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject?.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataClass), System.Text.Encoding.UTF8, "Application/Json"));
        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });
            return config.CreateMapper();
        }
        public void Dispose() { }
    }
}
