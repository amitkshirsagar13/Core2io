FROM microsoft/dotnet:2.1.301-sdk AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./

RUN dotnet build

FROM build AS publish
RUN dotnet publish -o out /property:PublishWithAspNetCoreTargetManifest=false 

FROM microsoft/dotnet:2.1.301-sdk AS runtime
WORKDIR /app

COPY --from=publish /app/out ./
RUN mkdir /https
COPY ./https/ /https

ENTRYPOINT ["dotnet", "Core2io.dll"]


#docker run --rm --name core2io-service -p 8000:80 -p 2424:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=2424 -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" -e ASPNETCORE_Kestrel__Certificates__Default__Path=\https\core2io.pfx core2io-service

#docker run --rm -it -p 2424:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" -e ASPNETCORE_Kestrel__Certificates__Default__Path=\https\core2io.pfx 

# docker run --name core2io-service -p 8081:80 -p 8443:443 core2io-service
# https://localhost:8443/core2io/api/test
# https://localhost:8443/swagger/index.html