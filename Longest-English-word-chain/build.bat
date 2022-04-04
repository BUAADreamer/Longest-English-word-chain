csc /target:library /out:Library.dll .\Input.cs .\Output.cs .\LibraryException.cs
csc /target:library /out:Core.dll .\Core.cs .\CoreException.cs .\PairTestInterface.cs
csc /out:WordList.exe *.cs
del ..\guiproject\guiproject\Core.dll
del ..\guiproject\guiproject\Library.dll
del ..\guiproject\guiproject\HYCore.dll
del Core.dll
del Library.dll
xcopy .\*.dll ..\guiproject\guiproject\