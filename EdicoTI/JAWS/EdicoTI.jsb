JFW Script File                                                          l  uia.jsb edico.jsb `    $altf              getcurrentwindow      getappmainwindow      fsuiagetelementfromhandle   '        3u    Z�    fsuiacreateintpropertycondition '  %          %    findfirst   '  %              fsuiacreatetruecondition      findfirst       getlegacyiaccessiblepattern '  %      dodefaultaction       �     edicotisayline                  getobjectdescription    1 WND_LINEAR_EDITOREditor lineare 
             1
 cmsgBlank1blank   saymessage             sayline    	         L    sayobjectwithdifferentname               getfocus                  %     getobjectname   %  %    stringreplacesubstrings   ..    .     stringreplacesubstrings      getobjecttype           %     getobjectstate                      %     getobjectvalue    saycontrolex          �     isinedicoactivationdialog           getforegroundwindow   getwindowname   1 WND_ACTIVATION_DIALOGAttivazione di Edico   
     	      �    isininsertsymboldialog                  getobjectname         
  # �         getforegroundwindow   getwindowname         
  
  # �           getobjecttypecode        
  
          fsuiacontrolviewwalker  '        fsuiagetfocusedelement  %   !  currentelement  %       gotopriorsibling       %       currentelement      controltype   X�  
             	                  	      <    reportpanetoggle            getobjectdescription    1 WND_LINEAR_EDITOREditor lineare 
          5u  %   	  fsuiacreatestringpropertycondition  '       fsuiacontrolviewwalker  '       fsuiagetfocusedelement  %  !  currentelement  %      gotoparent     %      gotoparent     %      currentelement         %    findfirst   '  %   '  %     %        
  1 cmsgOnOn    
  '     %        
  1 cmsgOffOff  
  '          Message %         sayusingvoice              	               	          autostartevent       getjfwversion   '   %     `# 
  # X %     (# 
  
        1 E La presente installazione di JAWS 2022 non è supportata.
Si prega di aggiornare JAWS 2022 alla versione JAWS2022.2206.9 o successiva per utilizzare EDICO.
Per scaricare l'ultima versione disponibile di JAWS 2022, scegliere "Controlla aggiornamenti" dal menu Aiuto di JAWS.     messagebox             OSM   HookingMode              readsettinginteger  &  giosmhookingmode         autostartevent     	      �     getcellcoordinates    � �        getforegroundwindow   getwindowname   1 WND_PERIODIC_TABLEEdico Tavola periodica    
              	         %   %    getcellcoordinates     	      p    keypressedevent       %     %  
  " L %       
  
       %  '      %    F2  
  # �    1 WND_BRAILLE_VIEWERVisualizzatore Braille      reportpanetoggle    
     	      %    F4  
  # 0   1
 WND_GRAPHIC_VIEWERVisualizzazione reale   reportpanetoggle    
     	         %   %  %  %    keypressedevent    	          sayline $  comobj            Edico.EdicoComObj     getobject   &  comobj     $  comobj  # � $  comobj      hasobject   
     $  comobj      getline '   %             edicotisayline     	              sayline    	      `    saycharacter      >,;:*?+=<}  '        ispccursor            saycharacter       	           getobjectdescription    1 WND_LINEAR_EDITOREditor lineare 
          saycharacter       	           getcharacterfont      edico_es_chem   
          saycharacter       	           getcharacter    '     %   %    stringcontains            saycharacter       	                   getfocus      �                 sendmessage '  %        
          saycharacter       	      %    ��  
  '  %       
  '       getobjectvalue  '  %        
     %       
  '     %  %         substring   '     %   %    stringcontains             '     %    getcharactervalue     A   
  # H   %    getcharactervalue     Z   
  
  '  %     %    getcharactervalue     a   
  # �   %    getcharactervalue     z   
  
  
  '  %        
                   %   %    stringcontains       
    inttostring   saymessage             saycharacter              d           sayobjecttypeandtext             isinedicoactivationdialog                 %     getobjectname     Identificador de equipo:      stringcontains        %     Identificador de equipo:    1 CTL_PC_CODEIdentificatore pc:     sayobjectwithdifferentname     	                 %     getobjectname     Ejecutar demo     stringcontains        %     Ejecutar demo   1 CTL_RUN_DEMOEsegui demo   sayobjectwithdifferentname     	         %         
  #      isininsertsymboldialog  
             getfocus    1	 CTL_INSERT_SYMBOLInserisci simbolo       getobjecttype           %     getobjectstate                      %     getobjectvalue    saycontrolex       	         %   %    sayobjecttypeandtext       	      �    brailleaddobjectname            isinedicoactivationdialog                         getobjectname     Identificador de equipo:      stringcontains                           getobjectname     Identificador de equipo:    1 CTL_PC_CODEIdentificatore pc:     stringreplacesubstrings                     brailleaddstring               	                         getobjectname     Ejecutar demo     stringcontains                           getobjectname     Ejecutar demo   1 CTL_RUN_DEMOEsegui demo   stringreplacesubstrings      getcursorcol         getcursorrow            brailleaddstring               	            %     brailleaddobjectname       	      h    newtextevent             $  comobj            Edico.EdicoComObj     getobject   &  comobj     $  comobj  # � $  comobj      hasobject   
  # � $  comobj      isbrailleline        
  
  '  %  #  $  giosmhookingmode         
  
     	         %   %  %  %  %  %  %    newtextevent          