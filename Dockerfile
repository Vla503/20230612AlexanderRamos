#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /Api

EXPOSE 8081
# Copy everything
COPY ./Api .

COPY ./Core ../Core
COPY ./Data ../Data
COPY ./Handlers ../Handlers
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Api
COPY --from=build-env /Api/ ./
ENTRYPOINT ["dotnet", "out/Api.dll"]
