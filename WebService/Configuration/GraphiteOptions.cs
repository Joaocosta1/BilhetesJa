using System.ComponentModel;

namespace WebService.Configuration
{
    public class GraphiteOptions
    {
        public string Protocol { get; set; }
        
        [Description("In Seconds")]
        public int BackoffPeriod { get; set; }
        
        [Description("In Seconds")]
        public int FailuresBeforeBackoff { get; set; }
        
        [Description("In Seconds")]
        public int Timeout { get; set; }
        
        [Description("In Seconds")]
        public int FlushInterval { get; set; }
    }
}