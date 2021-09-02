## Deploying to AWS lambda

1. `docker build --file ./dockerfile . --tag dotnet-perf`
2. `docker run --rm --volume some_absolute_path_to_folder:/volume dotnet-perf`
3. Upload `deployment-archive.zip` AWS lambda

