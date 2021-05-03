import sanic,json,hashlib,time,os,asyncio
from sanic.response import raw
from json import load
from sanic_ipware import get_client_ip
from replit import db
sha256 = hashlib.sha256()
sha1 = hashlib.sha1()
now = '"'+str(time.time())+'"'
import requests
app = sanic.Sanic("APPNAME")
from files.workers.mcp import *
from files.workers.fortnite import *
from files.workers.matchmaking import *
#versioncheck
@app.route('/fortnite/api/v2/versioncheck/<ver>', methods=['POST', 'GET'])
async def test(request,ver: str): 
    return sanic.response.json({"type":"NO_UPDATE"})
#enabled_features
@app.route('/fortnite/api/game/v2/enabled_features', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.json([])
#catalog
@app.route('/fortnite/api/storefront/v2/catalog', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.json([])
#timeline
@app.route('/fortnite/api/calendar/v1/timeline', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.json([{"channels":{"client-events":{"states":[{"state":{"seasonNumber":3,"seasonTemplateId":"AthenaSeason:athenaseason3","seasonBegin":"0001-06-23T04:00:00Z","seasonEnd":"9999-07-23T04:00:00Z","seasonDisplayedEnd":"9999-07-23T04:00:00Z"}}]}},"currentTime": "9998-06-23T04:00:00Z"}
])
@app.route('/socialban/api/public/v1/<accountid>', methods=['POST', 'GET'])
async def test(request,accountid: str):
  return sanic.response.empty()
@app.route('/fortnite/api/storefront/v2/keychain', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.redirect('https://api.nitestats.com/v1/epic/keychain')
#cloudstorage
with open("files/cloudstorage/DefaultEngine.ini") as f:
  DefaultEngine = f.read()
with open("files/cloudstorage/DefaultEngine.ini") as f:
  DefaultEnginel = len(f.readlines())
with open("files/cloudstorage/DefaultGame.ini") as f:
  DefaultGame = f.read()
with open("files/cloudstorage/DefaultGame.ini") as f:
  DefaultGamel = len(f.readlines())
with open("files/cloudstorage/DefaultRuntimeOptions.ini") as f:
  DefaultRuntimeOptions = f.read()
with open("files/cloudstorage/DefaultRuntimeOptions.ini") as f:
  DefaultRuntimeOptionsl = len(f.readlines())
sha1.update(DefaultGame.encode())
dghash1 = '"'+ sha1.hexdigest() +'"'
sha1.update(DefaultEngine.encode())
dehash1 = '"'+ sha1.hexdigest() +'"'
sha1.update(DefaultRuntimeOptions.encode())
drohash1 = '"'+ sha1.hexdigest() +'"'
sha256.update(DefaultGame.encode())
dghash256 = '"'+ sha256.hexdigest() +'"'
sha256.update(DefaultEngine.encode())
dehash256 = '"'+ sha256.hexdigest() +'"'
sha256.update(DefaultRuntimeOptions.encode())
drohash256 = '"'+ sha256.hexdigest() +'"'
cloudstorage = json.loads("""[{"uniqueFilename":"DefaultEngine.ini","filename":"DefaultEngine.ini","hash":""" +dehash1+ ""","hash256":""" +dehash256+ ""","length":"""+str(DefaultEnginel)+""","contentType":"application/octet-stream","uploaded":"someday","storageType":"S3","doNotCache":false},{"uniqueFilename":"DefaultGame.ini","filename":"DefaultGame.ini","hash":""" +dghash1+ ""","hash256":""" +dghash256+ ""","length":"""+str(DefaultGamel)+""","contentType":"application/octet-stream","uploaded":"someday","storageType":"S3","doNotCache":false},{"uniqueFilename":"DefaultRuntimeOptions.ini","filename":"DefaultRuntimeOptions.ini","hash":"""+drohash1+""","hash256":"""+drohash256+""","length":"""+str(DefaultRuntimeOptionsl)+""","contentType":"application/octet-stream","uploaded":"someday","storageType":"S3","doNotCache":false},{"uniqueFilename":"config","filename":"config","hash":"da39a3ee5e6b4b0d3255bfef95601890afd80709","hash256":"e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855","length":0,"contentType":"application/octet-stream","uploaded":"someday","storageType":"S3","doNotCache":false}]""")
#sending cloudstorage files
@app.route('/fortnite/api/cloudstorage/system', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.json(cloudstorage)
@app.route('/fortnite/api/cloudstorage/system/DefaultEngine.ini', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.raw(DefaultEngine)
@app.route('/fortnite/api/cloudstorage/system/DefaultGame.ini', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.raw(DefaultGame)
@app.route('/fortnite/api/cloudstorage/system/DefaultRuntimeOptions.ini', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.raw(DefaultRuntimeOptions)
@app.route('/fortnite/api/cloudstorage/system/config', methods=['POST', 'GET'])
async def test(request):
    return sanic.response.raw('')
    