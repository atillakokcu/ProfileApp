using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileApp.Business.Interfaces;
using ProfileApp.Business.Mappings.AutoMapper;
using ProfileApp.Business.Services;
using ProfileApp.Business.ValidationRules;
using ProfileApp.DataAccess.Context;
using ProfileApp.DataAccess.UnitOfWork;
using ProfileApp.Dto.TblActivationDtos;
using ProfileApp.Dto.TblAppRoleDtos;
using ProfileApp.Dto.TblStatusDtos;
using ProfileApp.Dto.TblUserAccountDtos;
using ProfileApp.Dto.TblUserDtos;

namespace ProfileApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserAppContext>(opt =>
            {
                //opt.UseSqlServer("Server =104.247.167.130\\MSSQLSERVER2022; Database = followac_UserAppDb; Integrated Security=True; Trusted_Connection = True; TrustServerCertificate=True", providerOptions => providerOptions.EnableRetryOnFailure());
                opt.UseSqlServer(@"server=104.247.167.130\MSSQLSERVER2022;database=followac_UserAppDb;user=followac_godswhip;password=Atilla_1994;TrustServerCertificate=True", providerOptions => providerOptions.EnableRetryOnFailure());
            });


            var mapperConfiguraiton = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new TblActivationProfile());
                opt.AddProfile(new TblAppRoleProfile());
                opt.AddProfile(new TblStatusProfile());
                opt.AddProfile(new TblUserAccountProfile());
                opt.AddProfile(new TblUserProfile());
                opt.AddProfile(new TblUserRoleProfile());
            });
            var mapper = mapperConfiguraiton.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<TblActivationCreateDto>, TblActivationCreateDtoValidator>();
            services.AddTransient<IValidator<TblActivationUpdateDto>, TblActivationUpdateDtoValidator>();
            services.AddTransient<IValidator<TblAppRoleCreateDto>, TblAppRoleCreateDtoValidator>();
            services.AddTransient<IValidator<TblAppRoleUpdateDto>, TblAppRoleUpdateDtoValidator>();
            services.AddTransient<IValidator<TblStatusCreateDto>, TblStatusCreateDtoValidator>();
            services.AddTransient<IValidator<TblStatusUpdateDto>, TblStatusUpdateDtoValidator>();
            services.AddTransient<IValidator<TblUserAccountCreateDto>, TblUserAccountCreateDtoValidator>();
            services.AddTransient<IValidator<TblUserAccountUpdateDto>, TblUserAccountUpdateDtoValidator>();
            services.AddTransient<IValidator<TblUserCreateDto>, TblUserCreateDtoValidator>();
            services.AddTransient<IValidator<TblUserUpdateDto>, TblUserUpdateDtoValidator>();
            services.AddTransient<IValidator<UserLoginDto>, UserAppLoginDtoValidator>();


            services.AddScoped<IActivaitonService,ActivationService>();
            services.AddScoped<IAppRoleService, AppRoleService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IUserService, UserService>();





        }
    }
}
