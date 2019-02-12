#only for python 3.1.2; comment this line out if you are using python 2.6.5
from tkinter import *
#comment this line in if you are using python 2.6.5
#from Tkinter import *

from ctypes import *
import sqlite3

LL = windll.cmll24

# connect to database
SQLCon = sqlite3.connect("simple.db3")
SQLCur = SQLCon.cursor()
FileName = c_wchar_p("sample.lbl")

class Application(Frame):
	def __init__(self, master=None):
		Frame.__init__(self, master)
		self.grid()
		self.createWidgets()
	
	def createWidgets(self):
		self.appLabelDE = Label ( self, text="D: Dieses Beispiel demonstriert das Designen und Drucken von Etiketten",   justify=LEFT )
		self.appLabelDE.grid()
		self.appLabelUS = Label ( self, text="US: This example demonstrates how to design and print labels", justify=LEFT )
		self.appLabelUS.grid()
		self.designButton = Button ( self, text="Design...", command=self.dodesign, width=50 )
		self.designButton.grid()
		self.printButton = Button ( self, text="Preview...", command=self.doprint, width=50 )
		self.printButton.grid()
		
	
	#------------------------------------------------------------------------------	
	def defineVariables(self, hJob, row):		
		columnID = 0		
		for d in SQLCur.description:				
			LL.LlDefineVariableW(hJob, c_wchar_p(d[0]), c_wchar_p(row[columnID]))
			columnID = columnID + 1
										
	
	#------------------------------------------------------------------------------	
	def dodesign(self):
		SQLCur.execute("select * from Persons")
		hJob = LL.LlJobOpen(c_int(0))		
		# activate debugging
		#LL.LlSetDebug(c_int(1))
		# define variables
		row = SQLCur.fetchone()
		self.defineVariables(hJob, row)
		# you can add some indepandent variables here
		LL.LlDefineVariableW(hJob, c_wchar_p("Var1"), c_wchar_p("Var1Contents"))
		# ...
		
		# display designer
		LL.LlDefineLayoutW(hJob, 0, c_wchar_p("Sample Title"), 1, FileName)
		LL.LlJobClose(hJob)		
		#tkm.showwarning("","Print dummy")
	
	#------------------------------------------------------------------------------	
	def doprint(self):
		SQLCur.execute("select * from Persons")
		hJob = LL.LlJobOpen(c_int(0))
		# activate debugging
		#LL.LlSetDebug(c_int(1))
		# define variables
		row = SQLCur.fetchone()
		self.defineVariables(hJob, row)
		# you can add some indepandent variables here
		LL.LlDefineVariableW(hJob, c_wchar_p("Var1"), c_wchar_p("Var1Contents"))		
		#...
		
		# start printing
		LL.LlPrintStartW(hJob
			, 1, FileName, 0, 0)
		
		LL.LlPrintSetOptionStringW(hJob
							, 2 	# LL_PRNOPTSTR_EXPORT
							, c_wchar_p("PRV"))
			
		# printing loop
		while row:
			self.defineVariables(hJob, row)
			LL.LlPrint(hJob)
			row = SQLCur.fetchone()
		
		
		LL.LlPrintEnd(hJob, 0)
		
		# display preview
		LL.LlPreviewDisplayW(hJob, FileName, "", 0)
		LL.LlPreviewDeleteFilesW(hJob, FileName, "")
		
		LL.LlJobClose(hJob)
		
				
##############################
app = Application()
app.master.title("List & Label sample application")
app.mainloop() 
