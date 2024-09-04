;(c) 2023-2024 Alberto Zanella            
; This file is part of the Edico Targato Italia distribution (https://github.com/xxxx or http://xxx.github.io).
; 
; This program is free software: you can redistribute it and/or modify  
; it under the terms of the GNU General Public License as published by  
; the Free Software Foundation, version 3.
;
; This program is distributed in the hope that it will be useful, but 
; WITHOUT ANY WARRANTY; without even the implied warranty of 
; MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
; General Public License for more details.
;
; You should have received a copy of the GNU General Public License 
; along with this program. If not, see <http://www.gnu.org/licenses/>.
;         
; KEY MAPPING FOR EDICO
;
;
#SingleInstance, Ignore

; %% variables
SetTitleMatchMode, 2
firstRun := False
timeBetweenChecks:=1000

; %% timer to check if edico is running, if so, call auto:
SetTimer,auto,%timeBetweenChecks%

; %% BEGIN MAPPINGS
;if edico is the current window
#IfWinActive, Edico
 
; Numeric keypad mapping
;standard keypad
NumpadDiv::Send {U+017E}

;with Control
^Numpad1::Send {U+0028}
^Numpad2::Send {U+28E6}
^Numpad3::Send {U+0153}
^Numpad6::Send {U+0062}
^Numpad7::Send {U+0078}
^Numpad9::Send {U+0061}
^NumpadDot::Send {U+003D}
^NumpadDiv::Send {U+002A}
^NumpadMult::Send {U+00EB}
^NumpadSub::Send {U+005E}
^NumpadAdd::^k
^Numpad8::SendInput, {F8}
^Numpad4::^d
^Numpad5::SendInput, {F5}

;with Alt
!NumpadDiv::Send {U+28F2}
!NumpadMult::Send {U+00B1}
!NumpadSub::Send {U+00A7}
!NumpadAdd::
SendInput, {Esc}
Send, ^i
Return

; %% END MAPPINGS
;
; %% Functions
ProcessExist(Name){
	Process,Exist,%Name%
	return Errorlevel
}

auto:
	if FileExist(A_Desktop . "\Edico.appref-ms")
	{
		FileDelete % A_Desktop . "\Edico.appref-ms"
	}
	if ( ProcessExist("Edico.exe" ))
	{
		;it has started at least one time
		%firstRun% := True
	}
	else
	{
		;if the Edico process started and now is not running, then exit...
		if(%firstRun%)
		{
			ExitApp
		}
	}
	Return