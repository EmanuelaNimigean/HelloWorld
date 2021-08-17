# HelloWorldWeb
## How to deploy to Keroku:

-build container (where the dockerfile is):
```
docker build -t imageName(ex:'ema_hww') .
```

-create docker container and run it
```
docker run -d -p 8081:80 --name ema_hww_container ema_hww
```

-login to Heroku:
```
heroku login
heroku container:login
```

-build the Dockerfile in the current directory and push the container
```
heroku container:push -a ema_hww_container web
```

-release the container.
```
heroku container:release -a ema_hww_container web

```