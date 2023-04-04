using R_Common;
using R_BackEnd;
using ProcessCommon;

namespace ProcessBack
{
    public class AttachFileCls : R_IAttachFile
    {
        public void R_AttachFile(R_AttachFilePar poAttachFile)
        {
            R_Exception loException = new R_Exception();
            string lcEmployeeId;
            string lcCmd;
            R_Db loDb;
            try
            {
                //User parameter Validation
                //harus ada User parameter
                var loVar = poAttachFile.UserParameters.Where((x) => x.Key.Equals(ProcessConstant.EMPLOYEE_ID)).FirstOrDefault().Value;
                if (loVar == null)
                {
                    loException.Add("001", "Employee ID parameter not found");
                    goto EndBlock;
                }
                lcEmployeeId = ((System.Text.Json.JsonElement)loVar).GetString();
                if (lcEmployeeId == null)
                {
                    loException.Add("001", "Employee ID parameter not found");
                    goto EndBlock;
                }

                //CoId	EmpId	FileName	oData	FileExtension
                lcCmd = $"Insert into TestEmployeeAttachment(CoId,EmpId,FileName,oData,FileExtension) values('{poAttachFile.Key.COMPANY_ID}','{lcEmployeeId}','{poAttachFile.File.FileDescription}',dbo.RFN_CombineByte('{poAttachFile.Key.COMPANY_ID}','{poAttachFile.Key.USER_ID}','{poAttachFile.Key.KEY_GUID}'),'{poAttachFile.File.FileExtension}' )";
                loDb = new R_Db();
                loDb.SqlExecNonQuery(lcCmd);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            EndBlock:
            loException.ThrowExceptionIfErrors();
        }
    }
}