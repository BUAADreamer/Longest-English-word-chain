csc /target:library /out:Library.dll .\Input.cs .\Output.cs .\LibraryException.cs
csc /target:library /out:Core.dll .\Core.cs .\CoreException.cs .\PairTestInterface.cs
csc /out:WordList.exe *.cs
xcopy .\Core.dll ..\guiproject\guiproject\
xcopy .\Library.dll ..\guiproject\guiproject\