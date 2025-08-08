namespace Lcx.Pmt.ExportData
{
    public class GoMain
    {
        public static string GamePath { get; set; } = @"E:\Pal3.0";
        public static string ModPath { get; set; } = $@"{GamePath}\PalMod";

        public static Resource? Resource { get; set; }

        public static void Init()
        {
            Resource = new Resource();
            Data.Init();
        }

        public static void Free()
        {
            Data.Free();
        }

        public static void Go(string? src, string? dest)
        {
            if (src != string.Empty && src != null) GamePath = src;
            if (dest != string.Empty && dest != null) ModPath = dest;

            Init();

            Data.Go();

            Free();
        }
    }
}
