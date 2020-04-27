FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11

COPY Compiler.fsproj Compiler.fs /source/

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Build once with nuget restore.
# RUN time /usr/bin/dotnet build -c Release /source/Compiler.fsproj

# RUN mkdir /compiler
RUN time /usr/bin/dotnet publish -c /Release -o /compiler /source/Compiler.fsproj

# --runtime linux-x64 -p:PublishReadyToRun=true

COPY Code.fs /tmp/

RUN time /usr/bin/dotnet /compiler/Compiler.dll  HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'

RUN time /compiler/Compiler HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'
