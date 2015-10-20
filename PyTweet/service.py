import json
import urllib
from tweetModel import Tweet

class TwitterService:
    def __init__(self, auth):
        self.client = auth.getClient()
        
    def getHomeTimeline(self, postCount = 20):
        """Retrieves the first [postcount] posts on a user's timeline. Returns an array of Tweet"""
        resp, content = self.client.request(str('https://api.twitter.com/1.1/statuses/home_timeline.json?count=' + str(postCount)), "GET")
        response = json.loads(content)
        tweets = []
        for tweet in response:
            tweets.append(Tweet(tweet))
            
        return tweets
        
    def postTweet(self, tweet):
        """Posts a tweet to the user's timeline."""        
        post = urllib.quote(tweet)
        resp, content = self.client.request(str('https://api.twitter.com/1.1/statuses/update.json?status=' + post), "POST")