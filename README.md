## Installing .net core 5 in linux
```
wget https://download.visualstudio.microsoft.com/download/pr/726e260e-ce94-46c3-a169-57b2ebf5433d/5fb2a00b04b3509a0a6db63e302523a8/dotnet-sdk-5.0.102-linux-arm.tar.gz

mkdir dotnet-arm32
tar zxf dotnet-sdk-5.0.102-linux-arm.tar.gz -C $HOME/dotnet-arm32

export DOTNET_ROOT=$HOME/dotnet-arm32
export PATH=$PATH:$HOME/dotnet-arm32

dotnet --info
```

## Running app
```
1. dotnet publish -c Release -r linux-arm --self-contained true
2. ./bin/Release/net5.0/linux-arm/dotnet-perf
```
