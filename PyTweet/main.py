import authorization
import data
import webbrowser as wb
import os.path
import service
import view
import pinDialog
import Tkinter as tk
import tkMessageBox
import tkFileDialog

class Controller():
    def __init__(self):
        self.root = tk.Tk()
        self.root.protocol('WM_DELETE_WINDOW',lambda: self._quit(None))
        self.root.title("PyTweet")
        self.view = view.PyTweet_Client(self.root)
        self.view.registerMenu(lambda: self.startAuth(), lambda: self.saveCredentials(None), lambda: self.loadCredentials(None), lambda: self._quit(None))
        
        self.root.deiconify()        
        self.root.geometry("540x370")
        self.root.resizable(False, False)              
                
        if (os.path.exists('data.dat')):
            try:    
                self.auth = data.loadCredentials()
                self.postAuth()
            except:
                os.remove('data.dat')
                if (tkMessageBox.askyesno(message="Invalid credentials found.\nWould you like to authorize PyTweet?")):    
                    self.startAuth()
        else:
            if (tkMessageBox.askyesno(message="No saved credentials found.\nWould you like to authorize PyTweet?")):    
                self.startAuth()
                
    
    def startAuth(self):
        """Creates an Authorizer and orchestrates the three-legged authentication."""
        
        auth = authorization.Authorizer()
        
        """Open a browser window so the user can approve PyTweet"""
        wb.open_new(auth.getRequestToken())
        
        """Show a dialog for the user to enter their pin"""
        pd = pinDialog.PinDialog(self.root)
        if (hasattr(pd, "pin")):
            auth.getToken(pd.pin)
        
        """Verify authorization was successful and perform post-auth setup"""
        if (auth.authorization_complete):
            self.auth = auth
            self.postAuth()
            tkMessageBox.showinfo(message="Authorization successful!")
        else:
            tkMessageBox.showerror(message="Authorization not successful.")       
        
    def postAuth(self):
        """Actions needed after a change of authorization"""
        self.tservice = service.TwitterService(self.auth)
        self.bindUI()
        self.getTweets(None)

    def bindUI(self):
        """Binds UI elements for interactivity"""
        self.view.refreshButton.unbind("<ButtonRelease-1>")
        self.view.refreshButton.bind("<ButtonRelease-1>", self.getTweets)
        self.view.tweetButton.unbind("<ButtonRelease-1>")
        self.view.tweetButton.bind("<ButtonRelease-1>", self.tweet)

    def getTweets(self, event):
        """Pull tweets from the TwitterService"""
        count = self.view.getTweetCount()
        tweets = self.tservice.getHomeTimeline(count)
        self.view.updateTweets(tweets)
        
    def tweet(self, event):
        """Post a tweet from the text input"""
        tweet = self.view.postTweet()
        self.tservice.postTweet(tweet)
        self.getTweets(None)
        
    def loadCredentials(self, event):
        """Load an Authorizer instance from a file"""
        filePath = tkFileDialog.askopenfilename(filetypes=[("Data files", "*.dat")])
        self.auth = data.loadCredentials(filePath)
        self.postAuth()
        tkMessageBox.showinfo("Data loaded", "Authentication Data Loaded!")
        
    def saveCredentials(self, event):
        """Save the current Authorizer instance to disk"""
        if (hasattr(self, "auth")):
            data.saveCredentials(self.auth)
        if (event != "exiting"):
            tkMessageBox.showinfo("Data saved", "Authentication Data Saved!")

    def run(self):
        self.root.mainloop()       

    def _quit(self, event):
        if (hasattr(self, 'auth')  and self.auth.authorization_complete):
            event = "exiting"
            self.saveCredentials(event)
        self.root.quit()
        self.root.destroy()
        

if __name__ == '__main__':
    c = Controller()
    c.run()