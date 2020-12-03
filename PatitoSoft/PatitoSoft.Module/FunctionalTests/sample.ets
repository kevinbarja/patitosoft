;#DropDB PatitoSoftEasyTest

#Application PatitoSoftWin
#Application PatitoSoftWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef PatitoSoftWin

*Action About...
 
*Action OK

#EndIf

#IfDef PatitoSoftWeb
*Action Navigation(My Details)
#EndIf
