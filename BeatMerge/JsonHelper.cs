using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using BeatMerge.Items;

namespace BeatMerge
{
    public static class JsonHelper
    {
        public static Map LoadMap(string jsonFile)
        {
            try
            {
                using (StreamReader re = new StreamReader(jsonFile))
                {
                    string json = re.ReadToEnd();
                    return JsonConvert.DeserializeObject<Map>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
