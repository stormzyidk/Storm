from files.workers.api import *
@app.route('/content/api/pages/fortnite-game', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.json(json.load(open("news.json")))
@app.route('/account/api/public/account/<accountid>', methods=['POST', 'GET'])
async def test(request,accountid: str):
    open("hi.txt","w+").write(request.args['Authorization'+"\n"])  
    dirr = f'files/config/profiles/{accountid}'
    if db.get(accountid) is None:
      db[accountid] = requests.get(f"https://fortnite-api.com/v1/stats/br/v2/{accountid}").json()["data"]["account"]["name"]
    return sanic.response.json({
   "ageGroup" : "UNKNOWN",
   "canUpdateDisplayName" : True,
   "country" : "PW",
   "displayName" : f"{db[accountid]}",
   "email" : "freeglitchesonyt@gmail.com",
   "emailVerified" : True,
   "failedLoginAttempts" : 0,
   "headless" : False,
   "id" : f"{accountid}",
   "lastLogin" : "2021-01-13T22:11:25.491Z",
   "lastName" : "trimix",
   "minorExpected" : False,
   "minorStatus" : "UNKNOWN",
   "minorVerified" : False,
   "name" : "Daddy",
   "numberOfDisplayNameChanges" : 0,
   "preferredLanguage" : "en",
   "tfaEnabled" : True
})
@app.route('username/<accountid>/<newusername>')
async def test(request,accountid: str,newusername: str):
  db[accountid] = newusername
  return sanic.response.text("Fuck you Trimi.")