csc /target:library /out:Library.dll .\Input.cs .\Output.cs .\LibraryException.cs
csc /target:library /out:Core.dll .\Core.cs .\CoreException.cs .\PairTestInterface.cs
csc /out:WordList.exe *.cs
del ..\guiproject\guiproject\Core.dll
del ..\guiproject\guiproject\Library.dll
del ..\guiproject\guiproject\HYCore.dll
del ..\cmdproject\cmdproject\Core.dll
del ..\cmdproject\cmdproject\Library.dll
del ..\cmdproject\cmdproject\HYCore.dll
xcopy .\*.dll ..\guiproject\guiproject\
xcopy .\*.dll ..\cmdproject\cmdproject\
del ..\bin\*.dll
del ..\bin\*.exe
xcopy .\Library.dll ..\bin\
xcopy .\Core.dll ..\bin\
xcopy .\WordList.exe ..\bin\