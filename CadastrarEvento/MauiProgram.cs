using Microsoft.Extensions.Logging;

namespace CadastrarEvento
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("1.ttf", "1");
                    fonts.AddFont("2.ttf", "2");
                    fonts.AddFont("3.ttf", "3");
                    fonts.AddFont("4.ttf", "4");
                    fonts.AddFont("5.ttf", "5");
                    fonts.AddFont("6.ttf", "6");
                    fonts.AddFont("7.ttf", "7");
                    fonts.AddFont("8.ttf", "8");
                    fonts.AddFont("9.ttf", "9");
                    fonts.AddFont("10.ttf", "10");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
