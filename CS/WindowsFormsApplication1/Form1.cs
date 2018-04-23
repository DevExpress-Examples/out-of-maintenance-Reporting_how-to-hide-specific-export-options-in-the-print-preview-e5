using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
// ...

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            PrintingSystem ps = new PrintingSystem();
            documentViewer1.PrintingSystem = ps;

            // Draw a simple text brick.
            ps.Begin();
            ps.Graph.DrawString("Some Text", new RectangleF(0, 20, 200, 20));
            ps.End();

            // Obtain its Export options.
            ExportOptions options = ps.ExportOptions;

            // Hide the "Never Embedded Fonts" option, if required.
            if (options.GetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts) != false) {
                options.SetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts, false);
            }

            // Hide all Document Options for PDF export.
            options.SetOptionsVisibility(new ExportOptionKind[] { ExportOptionKind.PdfDocumentApplication,
                ExportOptionKind.PdfDocumentAuthor, ExportOptionKind.PdfDocumentKeywords,
                ExportOptionKind.PdfDocumentSubject, ExportOptionKind.PdfDocumentTitle}, false);
        }
    }
}
