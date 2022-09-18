using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;

using System.Data;
using System.IO;

namespace DXMergeService
{
    public static class MergeService
    {

        public static byte[] Merge(string letterFilename, DataTable source, string outputFormat)
        {

            using (var srv = new RichEditDocumentServer())
            {
                srv.LoadDocument(letterFilename);
                srv.Options.MailMerge.DataSource = source;

                using (var target = new RichEditDocumentServer())
                {
                    var myOptions = srv.Document.CreateMailMergeOptions();
                    myOptions.FirstRecordIndex = 1;
                    myOptions.MergeMode = DevExpress.XtraRichEdit.API.Native.MergeMode.NewParagraph;

                    srv.MailMerge(target.Document);

                    if (outputFormat.ToUpper() == "PDF")
                    {
                        PdfExportOptions pdfOpts = new PdfExportOptions();

                        using (var file = new MemoryStream())
                        {
                            target.ExportToPdf(file, pdfOpts);
                            return file.ToArray();
                        }
                    }
                    else
                    {
                        using (var file = new MemoryStream())
                        {
                            target.SaveDocument(file, DocumentFormat.OpenXml);
                            return file.ToArray();
                        }
                    }
                }
            }
        }
    }
}
