using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ruler
{
    public class AppSettings
    {
        public List<Marker> Markers = new List<Marker>();
        public Size Size { get; set; }
        public Point Location { get; set; }

        public bool TopMost { get; set; }

        public AppSettings()
        {

        }

        public static void Save(AppSettings settings)
        {
            if (Directory.Exists(Program.appDataPath))
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    AllowTrailingCommas = true,
                    IncludeFields = true,
                    UnknownTypeHandling = System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonNode
                };

                string data = JsonSerializer.Serialize(
                    settings,
                    options
                    );

                File.WriteAllText(
                    Program.appDataPath + @"\settings.json",
                    data
                    );
            }
        }

        public static AppSettings Load()
        {
            AppSettings settings = new AppSettings();

            if (File.Exists(Program.appDataPath + @"\settings.json"))
            {
                string data = File.ReadAllText(
                    Program.appDataPath + @"\settings.json"
                    );

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    AllowTrailingCommas = true,
                    IncludeFields = true,
                    UnknownTypeHandling = System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonNode
                };

                settings = JsonSerializer.Deserialize<AppSettings>(
                    data,
                    options
                    );
            }

            return settings;
        }
    }
}
