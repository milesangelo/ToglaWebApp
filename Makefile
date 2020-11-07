# Project variables
PROJECT_NAME ?= ToglaWebApp

.PHONY: migrations db hello

migrations:
	cd ./Togla.Data && dotnet ef --startup-project ../Togla.Web/ migrations add $(mname) && cd ..

db:
	cd ./Togla.Data && dotnet ef --startup-project ../Togla.Web/ database update && cd ..

hello:
	echo 'Hello!'
