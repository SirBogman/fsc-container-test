FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11

COPY myapp1.fsproj Program.fs /source/

WORKDIR /source/

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Build once with nuget restore.
RUN time /usr/bin/dotnet build -c Release /source/myapp1.fsproj

# Simulate replacing program with new code.
RUN echo // comment >> Program.fs

# Build again without nuget restore.
RUN time /usr/bin/dotnet build -c Release --no-restore /source/myapp1.fsproj

# Run with --no-restore. Takes about 1.75 seconds.
RUN time /usr/bin/dotnet run -c Release --no-restore /source/myapp1.fsproj HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'

# Run with --no-restore --no-build. Takes about 0.65 seconds.
RUN time /usr/bin/dotnet run -c Release --no-restore --no-build /source/myapp1.fsproj HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'

# Run directly: takes about 0.14 seconds.
RUN time /usr/bin/dotnet /source/bin/Release/netcoreapp3.1/myapp1.dll HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'

RUN /usr/bin/dotnet --info
