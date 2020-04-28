FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine3.11

COPY Runner.fsproj Runner.fs /runner_source/

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Build once with nuget restore to obtain /root/.nuget/packages/fsharp.core/4.7.0/lib/netstandard2.0/FSharp.Core.dll
RUN time /usr/bin/dotnet build -c Release -o /runner/ /runner_source/Runner.fsproj

COPY Program.fs Program.runtimeconfig.json /source/

# Compile the code golf program.
RUN time /usr/bin/dotnet exec 																		\
	/usr/share/dotnet/sdk/3.1.201/FSharp/fsc.exe 													\
	--nologo 																						\
	--optimize 																						\
	--targetprofile:netcore 																		\
	--target:exe 																					\
	--noframework 																					\
	-r:/root/.nuget/packages/fsharp.core/4.7.0/lib/netstandard2.0/FSharp.Core.dll 					\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Collections.Concurrent.dll 		\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Collections.dll 					\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Console.dll 						\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Private.CoreLib.dll 				\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Resources.ResourceManager.dll	\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Runtime.Extensions.dll 			\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Runtime.Numerics.dll 			\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Runtime.dll 						\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Text.Encoding.Extensions.dll		\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Threading.dll 					\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Net.Requests.dll 				\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Net.WebClient.dll 				\
	-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/netstandard.dll 						\
	-o /source/Program.exe 																		\
	 /source/Program.fs

RUN ls -l /source

# Gives error: Unhandled exception. System.MethodAccessException: Entry point must have a return type of void, integer, or unsigned integer.
# RUN time /usr/bin/dotnet exec /source/Program.exe HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'

# Run it with the runner
RUN time /runner/Runner HI HIHI HIHIHI 💎💎 💎 "💎 💎💎" '💎💎 💎'
