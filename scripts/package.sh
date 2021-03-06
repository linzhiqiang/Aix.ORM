set -ex

cd $(dirname $0)/../

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

mkdir -p $artifactsFolder

dotnet restore ./Aix.ORM.sln
dotnet build ./Aix.ORM.sln -c Release


dotnet pack ./src/Aix.ORM/Aix.ORM.csproj -c Release -o $artifactsFolder
