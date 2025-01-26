using Serilog;
using System.Runtime.CompilerServices;

namespace Server.API.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication AddSerilog(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        return app;
    }
}
