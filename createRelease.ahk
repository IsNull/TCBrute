SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

deploymentDir := A_ScriptDir "\tcbrute"

if(FileExist(deploymentDir) == ""){
	; in case it doesnt exist
	FileCreateDir, %deploymentDir%
} else {
	; clean current depolyment folder
	loop, %deploymentDir%\.*
		FileDelete, % A_LoopFileFullPath
}
CopyCurrentReleaseBin(deploymentDir)
CopyCurrentReleaseInfo(deploymentDir)
return


CopyCurrentReleaseBin(target){
	source := A_ScriptDir "\truecryptbrute\bin\Release"
	
	if(FileExist(source) == "")
		MsgBox Can't find '%source%'
		
	FileCopyDir, %source%, %target%\bin
	if(ErrorLevel)
		MsgBox failed to copy release binarys
}

CopyCurrentReleaseInfo(target){
	readme := A_ScriptDir "\readme.txt"
	license := A_ScriptDir "\license.txt"
	
	FileCopy, % readme, % target
	FileCopy, % license, % target
}








