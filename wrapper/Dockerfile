FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11 as builder

COPY Compiler.fsproj Compiler.fs /source/

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Build once with nuget restore.
# RUN time /usr/bin/dotnet build -c Release /source/Compiler.fsproj

# RUN mkdir /compiler
RUN time /usr/bin/dotnet publish -c /Release -o /compiler /source/Compiler.fsproj

#  --runtime linux-musl-x64 -p:PublishReadyToRun=true 

RUN mkdir /empty


FROM scratch

COPY --from=0 /bin/cat                    \
              /bin/cp                     \
              /bin/rm                     \
              /bin/sh                     /bin/

COPY --from=0 /empty /tmp/

COPY --from=0 /lib/ld-musl-x86_64.so.1    \
        /lib/libcrypto.so.1.1       \
        /lib/libssl.so.1.1          /lib/

COPY --from=0 /bin/busybox /bin/ls /bin/

COPY --from=0 /usr/bin   /usr/bin/
COPY --from=0 /usr/lib   /usr/lib/
COPY --from=0 /usr/share/dotnet   /usr/share/dotnet/

COPY --from=0 /root /root/
COPY --from=0 /compiler /compiler/

COPY Code.fs /tmp/

RUN time /usr/bin/dotnet /compiler/Compiler.dll  HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'

RUN time /compiler/Compiler HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'
