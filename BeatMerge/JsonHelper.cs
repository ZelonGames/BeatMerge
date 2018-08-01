using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using BeatMerge.Items;

namespace BeatMerge
{
    public static class JsonHelper
    {
        public static T LoadJson<T>(string jsonFile)
        {
            try
            {
                using (StreamReader re = new StreamReader(jsonFile))
                {
                    string json = re.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return default(T);
            }
        }
    }
}
