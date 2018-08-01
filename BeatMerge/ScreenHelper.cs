using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatMerge
{
    public static class ScreenHelper
    {
        public static Dictionary<string, GroupBox> screens { get; private set; }

        public static readonly string screenSettings = "Settings";
        public static readonly string screenMergeSong = "MergeSong";
        public static readonly string screenChangeBPM = "ChangeBPM";

        public static void AddScreens(Form1 form)
        {
            screens = new Dictionary<string, GroupBox>();

            screens.Add(screenSettings, form.grpSettings);
            screens.Add(screenMergeSong, form.grpMerge);
            screens.Add(screenChangeBPM, form.grpBPM);
        }

        public static void ChangeScreen(Form1 form, string screenName)
        {
            if (!screens.ContainsKey(screenName))
                return;

            foreach (var screen in screens.Values)
            {
                if (screen.Name != screenName)
                    screen.Visible = false;
            }

            GroupBox currentScreen = screens[screenName];
            currentScreen.Visible = true;
            currentScreen.Top = form.menuStrip.Bottom + 10;

            form.Height = currentScreen.Bottom + currentScreen.Location.Y + 10;

            currentScreen.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
        }
    }
}
