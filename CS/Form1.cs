using System;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraPrinting;
// ...

namespace ExportVisibility {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a Printing System.
            PrintingSystem ps = new PrintingSystem();

            // Draw a simple text brick.
            ps.Begin();
            ps.Graph.DrawString("View the export options available in the toolbar",
                new RectangleF(0, 20, 300, 20));
            ps.End();

            // Obtain its Export options.
            ExportOptions options = ps.ExportOptions;

            // Hide the "Never Emdedded Fonts" option, if required.
            if(options.GetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts) != false) {
                options.SetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts, false);
            }

            // Hide all Document Options for PDF export.
            options.SetOptionsVisibility(new ExportOptionKind[] { ExportOptionKind.PdfDocumentApplication,
                ExportOptionKind.PdfDocumentAuthor, ExportOptionKind.PdfDocumentKeywords,
                ExportOptionKind.PdfDocumentSubject, ExportOptionKind.PdfDocumentTitle}, false);

            // Show the Print Preview form.
            ps.PreviewFormEx.Show();
        }

    }
}