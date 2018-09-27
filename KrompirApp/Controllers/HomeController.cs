using MessagingToolkit.QRCode.Codec;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KrompirApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GenerateQR()
        {
            var dir = Server.MapPath("~\\App_Data\\Temp\\");

            QRCodeEncoder encoder = new QRCodeEncoder();

            Bitmap img = encoder.Encode("Ovdje unosi tekst koji će se nalaziti u QR kodu. \n Koristi \n za odvajanje reda i ljepše formatiranje.");

            string fileName = DateTimeOffset.Now.Millisecond + "NazivProizvođača"; //Ovdje proslijedi naziv proizvođača ili šta god hoćeš

            try
            {
                img.Save(dir + fileName + ".png");
            }
            catch (Exception)
            {
            }

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/Etiketa.rdlc");

            localReport.EnableExternalImages = true;

            string imagePath = new Uri(dir + fileName + ".png").AbsoluteUri;

            var varTest = "Unosiš parametre za prikaz u PDF-u";

            ReportParameter paramTest = new ReportParameter("Test", "");
            if (varTest != null)
            {
                paramTest = new ReportParameter("Test", varTest.ToString());
            }
            
            ReportParameter imageParam = new ReportParameter("ImagePath", imagePath);

            localReport.SetParameters(paramTest);
            localReport.SetParameters(imageParam);

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0</MarginTop>" +
            "  <MarginLeft>0</MarginLeft>" +
            "  <MarginRight>0</MarginRight>" +
            "  <MarginBottom>0</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            System.IO.File.Delete(dir + fileName + ".png");

            TempData["success"] = "Uspješno ste generisali QR kod";

            return File(renderedBytes, mimeType);
        }
    }
}