﻿using System;
using System.Collections.Generic;

namespace MigAz.Forms.AWS
{
    public class TelemetryRecord
    {
        public Guid ExecutionId;
        public string AccessKeyId;
        public Dictionary<string, string> ProcessedResources;
        public string AWSRegion;
        public string SourceVersion;

    }
}
