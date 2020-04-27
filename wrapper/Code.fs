[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    argv |> Seq.iteri (printfn "Arg %i: %s")
    0
