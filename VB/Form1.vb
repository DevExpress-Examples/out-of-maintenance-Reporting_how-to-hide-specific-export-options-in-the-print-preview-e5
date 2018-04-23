Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraPrinting
' ...

Namespace ExportVisibility
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a Printing System.
			Dim ps As New PrintingSystem()

			' Draw a simple text brick.
			ps.Begin()
			ps.Graph.DrawString("View the export options available in the toolbar", New RectangleF(0, 20, 300, 20))
			ps.End()

			' Obtain its Export options.
			Dim options As ExportOptions = ps.ExportOptions

			' Hide the "Never Emdedded Fonts" option, if required.
			If options.GetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts) <> False Then
				options.SetOptionVisibility(ExportOptionKind.PdfNeverEmbeddedFonts, False)
			End If

			' Hide all Document Options for PDF export.
			options.SetOptionsVisibility(New ExportOptionKind() { ExportOptionKind.PdfDocumentApplication,  _
			    ExportOptionKind.PdfDocumentAuthor, ExportOptionKind.PdfDocumentKeywords, ExportOptionKind.PdfDocumentSubject, ExportOptionKind.PdfDocumentTitle}, False)

			' Show the Print Preview form.
			ps.PreviewFormEx.Show()
		End Sub

	End Class
End Namespace