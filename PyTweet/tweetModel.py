import HTMLParser

class Tweet:
    def __init__(self, tweet):
        """Creates a Tweet using the JSON structure provided from Twitter"""
        self.author = tweet['user']['screen_name']
        self.time = tweet['created_at']
        self.text = tweet['text']
        self.retweeted = bool(tweet['retweeted'])
        self.favorited = bool(tweet['favorited'])
        
    def __str__(self):
        h = HTMLParser.HTMLParser()
        return h.unescape(str(self.author + ": " + self.text + "\n" + self.time + "\n"))