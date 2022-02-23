﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;
using System.Text.RegularExpressions;

namespace SetVersionTask
{
    public class SetVersion : Task
    {
        [Required]
        public string FileName { get; set; }

        public string AssemblyVersion { get; set; }
        public string AssemblyFileVersion { get; set; }

        public override bool Execute()
        {
            try
            {
                if (this.FileName.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                {
                    var updater = new CSharpUpdater(AssemblyVersion, AssemblyFileVersion);
                    updater.UpdateFile(FileName);
                }
            }
            catch (Exception e)
            {
                Log.LogError(e.Message);
                return false;
            }
            return true;
        }
    }
}
