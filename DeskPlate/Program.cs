using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskPlate
{
    internal static class Program
    {
        private static PlateForm Plate;
        private static SettingsForm Settings;

        /// <summary>
        /// Entry Point
        /// </summary>
        [STAThread]

        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateNotifyIcon();

            Plate = new PlateForm();
            Settings = new SettingsForm();

            Application.Run(Plate);
        }
        // create tasktray icon
        private static void CreateNotifyIcon()
        {
            // create tasktray icon
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Text = "DeskPlate";
            notifyIcon.Icon = new System.Drawing.Icon("Icon.ico");
            notifyIcon.Visible = true;
            // add context menu
            notifyIcon.ContextMenuStrip = ContextMenu();
        }

        // function for context menu of tasktray icon
        private static ContextMenuStrip ContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Test", null, new EventHandler(Test));
            contextMenuStrip.Items.Add("Settings", null, new EventHandler(ShowSettings));
            contextMenuStrip.Items.Add("Exit", null, new EventHandler(Exit));
            return contextMenuStrip;
        }

        // Eventhndler to test
        private static void Test(object sender, EventArgs e)
        {
            //get the name of virtual desktop from windows api
            //show DeskPlate notification
            string text = "Test";
            Plate.notify(10000, text);
        }

        // Eventhandler to exit application
        private static void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Eventhandler to show settings form
        private static void ShowSettings(object sender, EventArgs e)
        {
            DialogResult dialogResult = Settings.ShowDialog();
        }

    }
}
