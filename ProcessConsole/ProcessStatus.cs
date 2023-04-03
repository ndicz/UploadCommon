﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_APICommonDTO;
using R_CommonFrontBackAPI;
using R_ProcessAndUploadFront;

namespace ProcessConsole
{
    public class ProcessStatus : R_IProcessProgressStatus
    {
        public Task ProcessComplete(string pcKeyGuid, eProcessResultMode poProcessResultMode)
        {
            throw new NotImplementedException();
        }

        public Task ProcessError(string pcKeyGuid, R_APIException ex)
        {
            throw new NotImplementedException();
        }

        public Task ReportProgress(int pnProgress, string pcStatus)
        {
            Console.WriteLine($"Step {pnProgress} with staus{pcStatus}");
            return Task.CompletedTask;
        }
    }
}
