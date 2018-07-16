FROM microsoft/dotnet:2.1.301-sdk AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./

RUN dotnet build

FROM build AS publish
RUN dotnet publish -o out /property:PublishWithAspNetCoreTargetManifest=false 

FROM microsoft/dotnet:2.1.1-runtime AS runtime
WORKDIR /app

COPY --from=publish /app/out ./
RUN mkdir /https
COPY ./https/ /https

ENTRYPOINT ["dotnet", "core2io.dll"]


#docker run --rm --name core2io-service -p 8000:80 -p 2424:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=2424 -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" -e ASPNETCORE_Kestrel__Certificates__Default__Path=\https\core2io.pfx core2io-service

#docker run --rm -it -p 2424:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" -e ASPNETCORE_Kestrel__Certificates__Default__Path=\https\core2io.pfx 