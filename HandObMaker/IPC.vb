Module IPC
	Public Sub SendToUnitSpriteStudio()
		Dim ExportImage = MainWindow.GenerateExportImage()

		Clipboard.SetData("HandObMakerExport", ExportImage)
	End Sub
End Module
