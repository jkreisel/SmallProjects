import urlparse
import oauth2 as oauth

# The logic for this class supplied by the Oauth2 example docs. Implementation mine.
# https://github.com/simplegeo/python-oauth2

class Authorizer:
    def __init__(self, credentials = None):
        self.authorization_complete = False
        self.consumer_key = '[KEYHERE]'
        self.consumer_secret = '[SECRETHERE]'
        self.request_token_url = 'https://twitter.com/oauth/request_token?oauth_callback=oob'        
        self.access_token_url = 'https://twitter.com/oauth/access_token'
        self.authorize_url = 'https://twitter.com/oauth/authorize'
        self.consumer = oauth.Consumer(self.consumer_key, self.consumer_secret)
        self.client = oauth.Client(self.consumer)
        self.oauth_token = ''
        self.oauth_secret = ''
        
        if (credentials is not None):
            self.oauth_token = credentials["oauth_token"]
            self.oauth_secret = credentials["oauth_secret"]
            self.authorization_complete = True
    
    def getRequestToken(self):
        """Gets a request token in order to prompt the user to authorize our app.        
        Returns an authorization URL."""
        
        """Get the request token"""
        response, content = self.client.request(self.request_token_url, "GET")
        if response['status'] != '200':
            raise Exception("Failed to get request token. Recieved HTTP %s." % response['status'])
        
        """Extract the request token from the response"""
        self.request_token = dict(urlparse.parse_qsl(content))
        
        """Return the authorization URL"""
        return ("%s?oauth_token=%s" % (self.authorize_url, self.request_token['oauth_token']))

    def getToken(self, pin):
        """Use our request token to request an access token, passing the PIN
        supplied by the user."""
        
        """Create a request token with the token, secret and PIN from Twitter."""
        token = oauth.Token(self.request_token['oauth_token'], self.request_token['oauth_token_secret'])
        token.set_verifier(pin)
        client = oauth.Client(self.consumer, token)
        
        """Request the access token with our request token."""
        response, content = client.request(self.access_token_url, "POST")
        access_token = dict(urlparse.parse_qsl(content))
        
        if ('oauth_token_secret' in access_token and 'oauth_token_secret' in access_token):
            self.token = oauth.Token(key=access_token['oauth_token'], secret=access_token['oauth_token_secret'])
            self.oauth_token = access_token['oauth_token']
            self.oauth_secret = access_token['oauth_token_secret']
            self.authorization_complete = True
    
    def getClient(self):
        """Returns an Oauth2 Client for making authenticated requests"""
        return oauth.Client(self.consumer, self.token)