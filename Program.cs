using IronPdf.Editing;
using IronSoftware.Drawing;

if(File.Exists("License.txt"))
    License.LicenseKey = File.ReadAllText("License.txt");


var pdf = new PdfDocument("input.pdf");


for (var i = 0; i < pdf.PageCount; i++)
{
    // attach to page
    var qrStamp = new BarcodeStamper(i.ToString(), BarcodeEncoding.QRCode)
    {
        Scale = 40,
        HorizontalAlignment = HorizontalAlignment.Right,
        VerticalAlignment = VerticalAlignment.Top,
        VerticalOffset = new Length(50, MeasurementUnit.Pixel),
        HorizontalOffset = new Length(30, MeasurementUnit.Pixel),
        IsStampBehindContent = true
    };

    pdf.ApplyStamp(qrStamp, i);


}


pdf.SaveAs("output.pdf");
