;JAWS Scripts for the EDICO Scientific Editor. Script modified from (c)
;Copyright 2022 Alberto Zanella - IRIFOR - https://www.irifor.eu
;EDICO v. 2.0.0.8 - Aug, 2023

include "hjconst.jsh"
Include "common.jsm"
include "uia.jsh"
include "edicoTI.jsm"
use "uia.jsb"
use "edico.jsb"

globals 
    int giOSMHookingMode

Const
	COM_OBJ="Edico.EdicoComObj",
	CTL_ESP_PC_CODE="Identificador de equipo:",
	CTL_ESP_RUN_DEMO="Ejecutar demo"

;Scripts
Script AltF ()
	var object mainWindow = FSUIAGetElementFromHandle(GetAppMainWindow (GetCurrentWindow ()))
	var object condition = FSUIACreateIntPropertyCondition(UIA_ControlTypePropertyId,UIA_MenuBarControlTypeId)
	var object element = mainWindow.FindFirst(TreeScope_Children,condition)
	element = element.FindFirst(TreeScope_Children,FSUIACreateTrueCondition()).GetLegacyIAccessiblePattern()
	element.DoDefaultAction()
EndScript

;EDICOToItalian specific functions: Functions that enhance EDICO behaviour for the Italian language
globals object COMObj

void function EdicoTISayLine()
	if GetObjectDescription (TRUE, 0) == WND_LINEAR_EDITOR Then
		SayMessage(OT_MESSAGE, cmsgBlank1 )
	Else return SayLine()
	EndIf
EndFunction

;Custom utils functions

void Function SayObjectWithDifferentName (int nLevel, string findString, string replaceString)
	SayControlEx (GetFocus (), StringReplaceSubstrings(StringReplaceSubstrings (GetObjectName (true, nLevel), findString, replaceString),"..","."), GetObjectType (), GetObjectState (TRUE, nLevel), "", "", GetObjectValue (TRUE, nLevel))
EndFunction

int Function isInEdicoActivationDialog ()
	return GetWindowName (GetForegroundWindow ()) == WND_ACTIVATION_DIALOG
EndFunction

int Function isInInsertSymbolDialog ()
	if (GetObjectName (true, 0) == "")
		&& (GetWindowName (GetForegroundWindow ()) == "") 
		&& (GetObjectTypeCode (true) == WT_EDIT)
	Then
		var object treeWalker = FSUIAControlViewWalker()
		treeWalker.currentElement = FSUIAGetFocusedElement()
		treeWalker.GoToPriorSibling()
		If treeWalker.currentElement.ControlType == UIA_ListControlTypeId Then return true EndIf
	EndIf
	Return false
EndFunction

int function ReportPaneToggle(string WND_NAME)
	If GetObjectDescription () == WND_LINEAR_EDITOR Then
		var object condition = FSUIACreateStringPropertyCondition(UIA_NamePropertyId,WND_NAME)
		var object treeWalker = FSUIAControlViewWalker()
		treeWalker.currentElement = FSUIAGetFocusedElement()
		treeWalker.GoToParent()
		treeWalker.GoToParent()
		var object result = treeWalker.currentElement.FindFirst(TreeScope_Descendants,condition)
		var string sMessage = WND_NAME
		if(result) Then
			sMessage = sMessage + " " + cmsgOn
		Else
			sMessage = sMessage + " " + cmsgOff
		EndIf
		SayUsingVoice (	VCTX_MESSAGE, sMessage, ot_user_requested_information)
		return true
	EndIf
	return false
EndFunction

;JAWS functions override

Void Function AutoStartEvent ()
	var int jawsVersion = GetJFWVersion()
	if (jawsVersion >= 2300000) && (jawsVersion < 2304017) Then
		MessageBox (cMsgBoxJaws23Warning)
	EndIf
	let giOSMHookingMode = ReadSettingInteger ("OSM", "HookingMode", 0, FT_CURRENT_JCF)
	return AutoStartEvent ()
EndFunction

int function GetCellCoordinates(int ByRef nCol, int ByRef nRow)
	if (GetWindowName (GetForegroundWindow ()) == WND_PERIODIC_TABLE)
		return FALSE
	EndIf
	return GetCellCoordinates(nCol, nRow)
EndFunction

Void Function KeyPressedEvent (int nKey, string strKeyName, int nIsBrailleKey, int nIsScriptKey)	
	if(nKey == 65573 || nKey == 65559) Then
		nKey = 1061
	EndIf
	if(strKeyName == "F2") && (ReportPaneToggle(WND_BRAILLE_VIEWER)) Then return
	ElIf(strKeyName == "F4") && (ReportPaneToggle(WND_GRAPHIC_VIEWER)) Then return
	EndIf
	return KeyPressedEvent (nKey, strKeyName, nIsBrailleKey, nIsScriptKey)
EndFunction

Void Function SayLine()
	var string txt
	if(!COMObj) Then
		Let COMObj = GetObject (COM_OBJ)
	EndIf
	If (COMObj && COMObj.HasObject()) then
		let txt = COMObj.GetLine ()
		if(!txt) then		
			return EdicoTISayLine()
		endif
	EndIf
    return SayLine()
EndFunction

Void Function SayObjectTypeAndText (optional int nLevel, int includeContainerName)
	if isInEdicoActivationDialog () Then
		if StringContains (GetObjectName (true, nLevel), CTL_ESP_PC_CODE) Then
			SayObjectWithDifferentName(nLevel, CTL_ESP_PC_CODE, CTL_PC_CODE)
			Return
		ElIf StringContains (GetObjectName (true, nLevel), CTL_ESP_RUN_DEMO) Then
			SayObjectWithDifferentName(nLevel, CTL_ESP_RUN_DEMO, CTL_RUN_DEMO)
			Return
		EndIf
	EndIf
	if (nLevel == 0) && isInInsertSymbolDialog ()
		SayControlEx (GetFocus (), CTL_INSERT_SYMBOL, GetObjectType (), GetObjectState (TRUE, nLevel), "", "", GetObjectValue (TRUE, nLevel))
		Return
	EndIf
	Return SayObjectTypeAndText (nLevel,includeContainerName)
EndFunction

int function BrailleAddObjectName(int iType)
	if isInEdicoActivationDialog () Then
		if StringContains (GetObjectName (true, 0), CTL_ESP_PC_CODE) Then
			BrailleAddString (StringReplaceSubstrings (GetObjectName (true, 0), CTL_ESP_PC_CODE, CTL_PC_CODE),0,0,0)
			return true
		elif StringContains (GetObjectName (true, 0), CTL_ESP_RUN_DEMO) Then
			BrailleAddString (StringReplaceSubstrings (GetObjectName (true, 0), CTL_ESP_RUN_DEMO, CTL_RUN_DEMO),GetCursorCol (), GetCursorRow (),0)
			return true
		EndIf
	EndIf
	return BrailleAddObjectName(iType)
EndFunction

Void Function NewTextEvent (Handle hwnd, String buffer, Int nAttributes, Int nTextColor, Int nBackgroundColor, Int nEcho, String sFrameName) 
	If (!COMObj) Then	
		 COMObj = GetObject (COM_OBJ)
	endif
	;Extra fire of NewTextEvent in some cases when HookingMode = 1 in this condition:
	var int edicoEspCondition = (COMObj && COMObj.HasObject() && COMObj.isBrailleLine == 1)
	;we prevent it:
	if(edicoEspCondition) && (giOSMHookingMode == 1) Then
		return
	EndIf
	NewTextEvent (hwnd, buffer, nAttributes, nTextColor, nBackgroundColor, nEcho, sFrameName)
EndFunction