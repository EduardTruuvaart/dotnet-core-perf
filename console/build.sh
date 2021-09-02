#!/bin/bash
# Build the project
dotnet publish ./dotnet-perf.csproj -c Release -r linux-musl-x64 --self-contained false /p:VersionPrefix="1.0.0" /p:PublishReadyToRun=true || exit 1
# Create a new directory where we will put deployment package
mkdir -p /package
# Go to bin folder with built project
cd  /build/bin/Release/netcoreapp3.1/linux-musl-x64/publish
# Archive deployment package and store it to the specified folder
zip -r /package/deployment-archive.zip . || exit 1
# Create the output directory in the mounted volume
mkdir -p /volume/package
# Copy the deployment package to the folder in the mounted volume
cd /package
cp -a deployment-archive.zip /volume/package || exit 1