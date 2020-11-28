# Project variables
PROJECT_NAME ?= ToglaWebApp

.PHONY: migrations db remove hello

migrations:
	cd ./Togla.Data && dotnet ef --startup-project ../Togla.Web/ migrations add $(mname) && cd ..

db:
	cd ./Togla.Data && dotnet ef --startup-project ../Togla.Web/ database update && cd ..

remove:
	cd ./Togla.Data && dotnet ef --startup-project ../Togla.Web/ migrations remove && cd ..

hello:
	echo 'Hello!'
