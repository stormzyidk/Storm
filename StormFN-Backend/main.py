from files.workers.api import *
port = 6969
for key in db.keys():
 del db[key]
 
@app.exception(sanic.exceptions.NotFound)
async def ignore_404s(request, exception):
  print(request.path)
  return sanic.response.json("python is cool?")
@app.exception(sanic.exceptions.InvalidUsage)
async def ignore_400s(request, exception):
  print(request.path)
  requests.get
  return sanic.response.json("stormfn gae")


print('\033[30;1m')
app.run(host="0.0.0.0", port=port)