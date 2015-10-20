import tkSimpleDialog
from Tkinter import *

class PinDialog(tkSimpleDialog.Dialog):
    """A simple dialog to capture the user's authentication PIN"""
    def body(self, master):
        Label(master, text="Pin:").grid(row=0)

        self.e1 = Entry(master)

        self.e1.grid(row=0, column=1)
        return self.e1 # initial focus
        
    def apply(self):
        self.pin = self.e1.get()