Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
' ...

Namespace WindowsFormsApplication1
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim ps As New PrintingSystem()
            documentViewer1.PrintingSystem = ps

            ' Draw a simple text brick.
            ps.Begin()
            ps.Graph.DrawString("Some Text", New RectangleF(0, 20, 200, 20))
            ps.End()

            ' Obtain its Export options.
            Dim options As ExportOptions = ps.ExportOptions

            ' Hide the "Never Embedded Fonts" option, if required.
            If options.GetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts) <> False Then
                options.SetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts, False)
            End If

            ' Hide all Document Options for PDF export.
            options.SetOptionsVisibility(New ExportOptionKind() { ExportOptionKind.PdfDocumentApplication, ExportOptionKind.PdfDocumentAuthor, ExportOptionKind.PdfDocumentKeywords, ExportOptionKind.PdfDocumentSubject, ExportOptionKind.PdfDocumentTitle}, False)
        End Sub
    End Class
End Namespace
