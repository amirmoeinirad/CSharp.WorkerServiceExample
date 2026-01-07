# BASE STAGE ---------------------------------------------------------

# Use the official .NET SDK image as the base image to run the app
# 'As base' creates an alias.
# The image will be downloaded from the Microsoft Container Registry.
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base

# Sets the working directory inside the container to /app. Any subsequent instructions will be relative to this directory.
# This is where the final app (published output) is stored and where the app will run from.
WORKDIR /app

# BUILD STAGE ---------------------------------------------------------

# Use the SDK image for building and publishing the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# Set the working directory inside the container to /src. This is where the source code will be copied to and built.
WORKDIR /src

# Copies the entire source code into the container's /src/WorkerServiceExample/ directory.
COPY . .

# Runs dotnet restore, which restores all the NuGet dependencies for the project.
RUN dotnet restore "WorkerServiceExample.csproj"

# Builds the application in Release configuration and outputs the build files to /app/build inside the container.
RUN dotnet build "WorkerServiceExample.csproj" -c Release -o /app/build

# PUBLISH ---------------------------------------------------------

# Starts from the previously defined build stage and aliases it as publish.
FROM build AS publish

# Runs dotnet publish, which compiles the application and prepares it for deployment. It outputs the published files into the /app/publish directory in the container.
RUN dotnet publish "WorkerServiceExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FINAL ---------------------------------------------------------

# Final stage: copy the build and run the app
# Starts the final stage from the base image. This is the image that will be used to run the application.
FROM base AS final

# Sets the working directory to /app (the directory where the published app will run from).
WORKDIR /app

# Copies the published files from the publish stage (/app/publish) into the current working directory /app in the final image.
COPY --from=publish /app/publish .

# Specifies the entry point for the container. 
# This tells Docker to run the 'dotnet WorkerService.dll' command, which will start your .NET Worker Service when the container is run.
ENTRYPOINT ["dotnet", "WorkerServiceExample.dll"]