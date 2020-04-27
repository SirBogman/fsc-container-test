open System.Reflection
open System.Runtime.CompilerServices
open FSharp.Compiler.SourceCodeServices

let runCode (assembly: Assembly) (args: string[]) =
    let entryPoint =
        assembly.GetTypes()
        |> Seq.map (fun t -> t.GetMethods())
        |> Seq.concat
        |> Seq.tryFind (fun m ->
            m.GetCustomAttributes(typeof<EntryPointAttribute>, true).Length > 0)

    match entryPoint with
    | Some method -> method.Invoke(null, [| args |]) |> unbox<int>
    | None ->
        assembly.GetTypes()
        |> Seq.iter (fun t -> RuntimeHelpers.RunClassConstructor(t.TypeHandle))
        0

[<EntryPoint>]
let main args =
    let checker = FSharpChecker.Create()
    let info, result, assembly =
        checker.CompileToDynamicAssembly([| "-o"; "/tmp/Code.exe"; "-a"; "/tmp/Code.fs"; "--targetprofile:netcore"; "--target:exe"; "--optimize"; "-r:FSharp.Core.dll"; "-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Private.CoreLib.dll"; "-r:/usr/share/dotnet/shared/Microsoft.NETCore.App/3.1.3/System.Runtime.dll"; "--win32manifest:/usr/share/dotnet/sdk/3.1.201/FSharp/default.win32manifest" |], None)
        |> Async.RunSynchronously

    printfn "Result: %d" result
    info |> Seq.iter (printfn "%O")
    if result <> 0 then
        result
    else
        runCode assembly.Value args
