# Donet version of a client app to talk to FHIR server

Simple example to show what is possible
* Uses dotnet core version 6
* Uses FHIR client for dotnet

# Development
* Use 'odo' client - OpenShift Do

# Deployment
* Use OpenShift gitlab import stategies - the code uses source to image

# Depedencies
* Deploy: https://github.com/yohanswanepoel/hapi-fhir-jpaserver-starter in common-tools namespace
* Load some data from synthea