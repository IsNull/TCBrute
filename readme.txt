+-------------------------------+
|           TCBrute 2           |
+-------------------------------+
| written by IsNull             |
|                               |
| v 3.01 pre ALpha              |
|                               |
+-------------------------------+


#License:

    TCBrute 2 - TrueCrypt VolumeHeader Bruteforcer	
    Copyright (C) 2010 -2012  IsNull @ securityvision.ch

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.


#SourceCode

You can get the Source from https://github.com/IsNull/TCBrute



#Build Requirments:

Visual Studio 2010 Professional or above/  Mono Develop 
NASM Compiler (-> nasm.exe must be accessible in the CMD -> put it in your Windows directory/ System32/SysWow32)



#How to build:

First you should build the TrueCrypt.dll, it is now configured as depency of TCBrute. Just Run in VS, it will build everything for you.


TCBrute (the C# part) can build without the truecrypt.dll, but for running, this dll is needed into the same directory as the truecryptbrute Exe resides.



visit us @ securityvision.ch
eOf