using System;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionContenido;
using Olimpiadas.Presentation.ServiceAgents.Proxy.GestionSeguridad;

namespace Olimpiadas.Web.CMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default", new CacheProfile()
                {
                    Location = ResponseCacheLocation.Any,
                    VaryByHeader = "User-Agent",
                    Duration = 31536000 //segundos de un año
                });
            });
            services.AddSignalR();

            services.Configure<GzipCompressionProviderOptions>(opts => opts.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = new[]
                {
                    // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json", 
                    // Custom
                    "image/svg+xml",
                    "application/font-woff2",
                };
            });

            services.AddAuthentication("PeruApps")
                .AddCookie("PeruApps", options =>
                {
                    options.LoginPath = "/";
                    options.LogoutPath = "/";
                    //options.CookieSecure = CookieSecurePolicy.Always; // bloquea password en http
                });

            services.AddCloudscribePagination();
            services.AddScoped<IGestionContenidoService, GestionContenidoServiceClient>();
            services.AddScoped<IGestionSeguridadService, GestionSeguridadServiceClient>();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(720);
            });

            services.AddHttpsRedirection(options => {
                options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                //Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(180);
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseHsts();
                //app.UseCookiePolicy(new CookiePolicyOptions // bloquea password en http
                //{
                //    HttpOnly = HttpOnlyPolicy.Always,
                //    Secure = CookieSecurePolicy.Always,
                //    MinimumSameSitePolicy = SameSiteMode.None
                //});
            }

            app.UseAuthentication();

            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("es-PE")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-PE"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });


            app.Use(async (context, next) =>
            {
                string nonce = Guid.NewGuid().ToString("N");
                string nonceHeader = string.Concat("nonce-", nonce);
                //context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                //context.Response.Headers.Add("X-Frame-Options", "DENY");
                //context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                //context.Response.Headers.Add("Referrer-Policy", "strict-origin");

                context.Response.Headers.Add("Content-Security-Policy",
                    "base-uri 'self';" +
                    //"default-src 'none';" +  //se tumba los recursos de estilo del login
                    //"script-src 'strict-dynamic' '" + nonceHeader + "';" +
                    //"font-src 'self' data: https://fonts.gstatic.com https://fonts.googleapis.com/;" +
                    ////"object-src 'none';" +
                    //"media-src 'self';" +
                    //"style-src 'strict-dynamic' '" + nonceHeader + "';" +
                    //"style-src-elem 'strict-dynamic' '" + nonceHeader + "' https://fonts.googleapis.com/ https://apis.google.com/ https://maps.googleapis.com/;" +
                    //"img-src 'self' data: https://maps.gstatic.com/ https://apis.google.com/ https://maps.googleapis.com/ http://*.promperu.gob.pe https://*.azurewebsites.net/ http://190.41.94.92/;" + //evita que aparezcan las imagenes
                    "frame-src 'self' https://apis.google.com/;" +
                    "frame-ancestors 'self';" +
                    //"connect-src 'self' https://apis.google.com/;" +
                    "form-action 'self';" +
                    "");

                context.Items["csp-nonce"] = nonce;
                await next();
            });

            // Set up custom content types - associating file extension to MIME type
            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".kml"] = "application/vnd.google-earth.kml+xml";

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("cache-control", new[] { "public,max-age=31536000" });
                    context.Context.Response.Headers.Add("Expires", new[] { DateTime.UtcNow.AddYears(1).ToString("R") }); // Format RFC1123
                },
                ContentTypeProvider = provider
            });

            app.UseResponseCompression();
            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseFileServer();

            app.UseSession();
            app.UseStaticFiles();
        }
    }
}