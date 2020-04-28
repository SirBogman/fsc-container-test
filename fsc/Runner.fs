open System.Reflection
open System.Runtime.CompilerServices

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
    printfn "About to run."
    let assembly = Assembly.LoadFrom "/source/Program.exe"
    runCode assembly args
