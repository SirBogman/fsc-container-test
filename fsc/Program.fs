open System

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    argv |> Seq.iteri (printfn "Arg %i: %s")
    AppDomain.CurrentDomain.GetAssemblies()
    |> Seq.map (fun x -> x.CodeBase)
    |> Seq.sort
    |> Seq.iter (printfn "%s")
    0
