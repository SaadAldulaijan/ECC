Gitlab access token:
username: saadaldulaijan
token: glpat-cf6_27ipgBtVFxSLxaqN

=======================================

dotnet nuget add source "https://gitlab.com/api/v4/projects/35605307/packages/nuget/index.json" --name GitLab --username SaadAldulaijan --password glpat-cf6_27ipgBtVFxSLxaqN

dotnet nuget push ECC.Shared.1.0.5.nupkg -s GitLab

