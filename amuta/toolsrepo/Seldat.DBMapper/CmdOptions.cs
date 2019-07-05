using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace Seldat.DBMapper
{
    class CmdOptions
    {
        [Option(Required = true, HelpText = "Data Provider of the target DB")]
        public string DataProvider { get; set; }

        [Option(Required = true, HelpText = "Connection string to target DB")]
        public string ConStr { get; set; }

        [Option(Required = true, HelpText = "Namespace to place on the top of the file")]
        public string Namespace { get; set; }

        [Option("TargetFolder", DefaultValue = "", Required = false, HelpText = "folder where class will be created, if empty - local folder")]
        public string TargetFolder { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }

    }

}
