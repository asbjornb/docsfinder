open System
open Folders

[<EntryPoint>]
let main argv =
    // Get optional path positional argument
    let path = 
        if argv.Length > 0 then argv.[0]
        else Environment.CurrentDirectory
    
    //Get folders, then check for readme and print results
    getFolders path |> Seq.map checkForReadme |> Seq.iter (printfn "%A")
    0 // return 0 exit code for success
