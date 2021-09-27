using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;

using PCLService.Data;
using PCLService.Helpers;
using PCLService.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;

namespace PCLService.Controllers
{
    public class MergeController : ApiController
    {
        // GET api/values
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */


        // POST api/Merge
        public byte[] Post([FromBody] CallData data)
        {

            try
            {

                var headers = HttpContext.Current.Response.Headers;
                headers.Add("Access-Control-Allow-Origin", "*");

                // Require key and timestamp
                if (string.IsNullOrEmpty(data.Key) ||
                    string.IsNullOrEmpty(data.TimeStamp))
                {
                    throw new InvalidOperationException();
                }

                // Generate our version of the key based on the timestamp
                using (var sha256 = SHA256.Create())
                {
                    var checkKey = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes("PastoralCompensationTool" + data.TimeStamp)));
                    if (checkKey != data.Key)
                    {
                        throw new InvalidOperationException();
                    }
                }

                data.ChurchName = data.ChurchName ?? string.Empty;
                data.PastorName = data.PastorName ?? string.Empty;
                data.City = data.City ?? string.Empty;
                data.State = StateHelper.GetLongName(data.State ?? string.Empty);

                if (data.WorldlyCareClause != null && data.WorldlyCareClause.ToUpper() == "YES")
                {
                    data.WorldlyCareClause = "Yes";
                }
                else
                {
                    data.WorldlyCareClause = "No";
                }
                
                data.OtherExpenses = data.OtherExpenses ?? string.Empty;
                data.InsuranceMessage = data.InsuranceMessage ?? string.Empty;                
                data.OutputFormat = data.OutputFormat?.ToUpper() ?? string.Empty;

                using (var srv = new RichEditDocumentServer())
                {
#if DEBUG
                    srv.LoadDocument(@"C:\Users\jfall\Documents\PastorCallLetter.docx");
#else
                    srv.LoadDocument(HttpContext.Current.Server.MapPath(@"~\PastorCallLetter.docx"));
#endif
                    var source = CallDataTableFactory.GetDataSource(data);
                    srv.Options.MailMerge.DataSource = source;

                    using (var target = new RichEditDocumentServer())
                    {
                        var myOptions = srv.Document.CreateMailMergeOptions();
                        myOptions.FirstRecordIndex = 1;
                        myOptions.MergeMode = DevExpress.XtraRichEdit.API.Native.MergeMode.NewParagraph;

                        srv.MailMerge(target.Document);

                        if (data.OutputFormat.ToUpper() == "PDF")
                        {
                            PdfExportOptions pdfOpts = new PdfExportOptions();                            

                            using (var file = new MemoryStream())
                            {
                                target.ExportToPdf(file, pdfOpts);
                                headers.Add("Content-Disposition", "attachment; filename=\"CallLetter.pdf\"");
                                headers.Add("Content-Type", "application/pdf");
                                return file.ToArray();
                            }
                        }
                        else
                        {
                            using (var file = new MemoryStream())
                            {
                                target.SaveDocument(file, DocumentFormat.OpenXml);
                                headers.Add("Content-Disposition", "attachment; filename=\"CallLetter.docx\"");
                                headers.Add("Content-Type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                                return file.ToArray();
                            }
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.ToString());
                return null;
            }
        }
    }
}
