using System;
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
        public string CompanyId { get; set; }
        public string UserId { get; set; }

        public Task ProcessComplete(string pcKeyGuid, eProcessResultMode poProcessResultMode)
        {
            if (poProcessResultMode == eProcessResultMode.Success)
            {
                Console.WriteLine($"Process Complete Succes with GUID {pcKeyGuid}");

            }
            else
            {
                Console.WriteLine($"Process Complete Fail with GUID {pcKeyGuid}");
            }
            return Task.CompletedTask;
        }

        public Task ProcessError(string pcKeyGuid, R_APIException ex)
        {
            foreach (R_Error item in ex.ErrorList)
            {
                Console.WriteLine($"Process Fail with GUID {pcKeyGuid}");
            }
            return Task.CompletedTask;
        }

        public Task ReportProgress(int pnProgress, string pcStatus)
        {
            Console.WriteLine($"Step {pnProgress} with status {pcStatus}");
            return Task.CompletedTask;
        }
    }
}