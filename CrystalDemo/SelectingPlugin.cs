using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace Crystal
{
    public partial class SelectingPlugin : Form
    {
        public string PluginType { get; set; }

        public string Result { get; set; }

        IAbout plugin = null;

        public SelectingPlugin()
        {
            InitializeComponent();
        }

        public SelectingPlugin(String _pluginType)
        {
            PluginType = _pluginType;

            InitializeComponent();
        }

        private void SelectingPlugin_Load(object sender, EventArgs e)
        {
            Program.settings.Update();

            Dictionary<string, string> plugins = new Dictionary<string, string>();

            switch (PluginType)
            {
                case "Table":
                    plugins = Program.settings.TablePluginList;
                    break;
                case "StoreMethod":
                    plugins = Program.settings.StorePluginList;
                    break;
            }

            foreach (KeyValuePair<string,string> plugin in plugins)
            {
                listPlugins.Items.Add(plugin.Key);
            }
        }

        private void listPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*switch (PluginType)
            {
                case "Table":
                    plugin = (IAbout)Plugins.Load(Program.settings.TablePluginList[listPlugins.SelectedItem.ToString()], typeof(ITable));
                    break;
                case "StoreMethod":
                    plugin = (IAbout)Plugins.Load(Program.settings.StorePluginList[listPlugins.SelectedItem.ToString()], typeof(IStoreMethod));
                    break;
            }*/
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Result = String.Join(";", listPlugins.SelectedItem.ToString(), txtParameters.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Result = "";
        }
    }
}
