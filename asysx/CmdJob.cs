using System;

namespace asysx
{
    public class CmdJob : BaseJob
    {
        public override string JobType => "cmd";

        public string Machine { get; set; }

        public string Box { get; set; }

        // Command
        public string Command { get; set; }
        public string StandardOutputFile { get; set; }
        public string StandardErrorFile { get; set; }

    }
}