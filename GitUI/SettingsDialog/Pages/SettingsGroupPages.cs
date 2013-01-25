﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitUI.SettingsDialog.Pages
{
    public class GitExtensionsSettingsGroup : GroupSettingsPage
    {
        public GitExtensionsSettingsGroup()
            : base("Git Extensions")
        {
        }

        public static SettingsPageReference GetPageReference()
        {
            return new SettingsPageReferenceByType(typeof(GitExtensionsSettingsGroup));
        }
    }

    public class PluginsSettingsGroup : GroupSettingsPage
    {
        public PluginsSettingsGroup()
            : base("Plugins")
        {
        }

        public static SettingsPageReference GetPageReference()
        {
            return new SettingsPageReferenceByType(typeof(PluginsSettingsGroup));
        }
    }

    public class AdvancedSettingsGroup : GroupSettingsPage
    {
        public AdvancedSettingsGroup()
            : base("Advanced")
        {
        }

        public static SettingsPageReference GetPageReference()
        {
            return new SettingsPageReferenceByType(typeof(AdvancedSettingsGroup));
        }
    }
}
