import requests
from files.workers.api import *
f = open("files/cache/cosmetics.json",'w+')
f.truncate(0)
data = requests.get("https://fortnite-api.com/v2/cosmetics/br").json()
for cos in data['data']:
  if str(cos['id']).startswith("CID"):
    f.write('''
    		"AthenaCharacter:'''+cos["id"]+'''": {
					"templateId": "AthenaCharacter:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("BID"):
    f.write('''
    		"AthenaBackpack:'''+cos["id"]+'''": {
					"templateId": "AthenaBackpack:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("Pickaxe"):
    f.write('''
    		"AthenaPickaxe:'''+cos["id"]+'''": {
					"templateId": "AthenaPickaxe:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("EID"):
    f.write('''
    		"AthenaDance:'''+cos["id"]+'''": {
					"templateId": "AthenaDance:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("Glider_"):
    f.write('''
    		"AthenaGlider:'''+cos["id"]+'''": {
					"templateId": "AthenaGlider:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("Trails_"):
    f.write('''
    		"AthenaSkyDiveContrail:'''+cos["id"]+'''": {
					"templateId": "AthenaSkyDiveContrail:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("MusicPack_"):
    f.write('''
    		"AthenaMusicPack:'''+cos["id"]+'''": {
					"templateId": "AthenaMusicPack:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("LSID_"):
    f.write('''
    		"AthenaLoadingScreen:'''+cos["id"]+'''": {
					"templateId": "AthenaLoadingScreen:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
for cos in data['data']:
  if str(cos['id']).startswith("Wrap_"):
    f.write('''
    		"AthenaItemWrap:'''+cos["id"]+'''": {
					"templateId": "AthenaItemWrap:'''+cos["id"]+'''",
					"attributes": {
						"max_level_bonus": 0,
						"level": 2,
						"item_seen": 1,
						"xp": 0,
						"variants": [],
						"favorite": false
					},
					"quantity": 1
				},''')
f.close()
with open("files/cache/cosmetics.json") as f:
  cosmaticsid = f.read()               
os.remove('files/cache/cosmetics.json')

