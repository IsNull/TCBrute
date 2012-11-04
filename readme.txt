+-------------------------------+
|      truecryptbrute 2         |
+-------------------------------+
| written by IsNull             |
|                               |
| v 2.01 pre ALpha              |
|                               |
+-------------------------------+


#License:

    truecryptbrute 2 - TrueCrypt VolumeHeader Bruteforcer	
    Copyright (C) 2010  IsNull @ securityvision.ch

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

Visual Studio 2010 Professional/ Mono Develop 
NASM Compiler (-> nasm.exe must be accessible -> put it in your Windows directory/ Sys32/SysWow32)



#How to build:

First you have to build the TrueCrypt.dll

1. Build the Crypto Project.
2.1 Build the Mount Project (note that this has significantly changed from the original TrueCrypt Source)
This will result into the Truecrypt.dll.

2.2 
The _stdcall conv falg forces the compiler to add a @[param byte number] suffix to each exported function, and visual studio didn't like @ into the functuion name o.0
For now, I decided to simply patch the builded dll. I changed the exported function name (remove the _ prefix and the _@[n] suffix).


truecryptbrute can build without the truecrypt.dll, but for running, this dll is needed into the same directory as the truecryptbrute Exe resides.



visit us @ securityvision.ch
eOf