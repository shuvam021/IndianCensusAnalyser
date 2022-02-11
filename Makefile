test:
	dotnet test Tests

run: test
	dotnet run -p IndianCensusAnalyser

slnup:
	dotnet sln add **/*.csproj