import cPickle as cp

def saveCredentials(oauth, path = "data.dat"):
    """Store credentials locally so the user doesn't have to reauthorize"""
    with open(path, 'wb') as outputFile:
        cp.dump(oauth, outputFile)
        
def loadCredentials(path = "data.dat"):
    """Retrieve saved credentials"""
    with open(path, 'rb') as inputFile:
        return cp.load(inputFile)