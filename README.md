# asp.net-core-3.1
Learn asp.net core 3.1, rest service, async, docker, openshift/minishift </br>

When the application is running, the rest service can be accessed at </br> 
https://localhost:5001/api/Employee

#Build application image and run container for the image
docker build -t mywebappexample -f Dockerfile .  </br>
docker run -d -p 8080:8080 --name mywebapp mywebappexample </br>

#Commonly use commands
docker container ls -a </br>
docker container rm 896935e93272 </br>
docker image rm 75835a67d134 2a4cca5ac898 </br>
docker image prune </br>
docker exec mywebapp ipconfig </br>
docker exec -it mywebapp /bin/sh (log into running container) </br>
docker run --entrypoint /bin/sh -it mywebappexample  (log into image) </br>
docker images -f dangling=true </br>
docker system prune </br>

#Clean up
docker container stop $(docker container ls -aq) </br>
docker container rm $(docker container ls -aq) </br>
docker image rm $(docker image ls  -aq) </br>

#Alternately, build and run in openshift/minishift from local source code
oc start-build myapp --from-dir=. --follow </br>
oc expose svc/myapp --port 8080 </br>