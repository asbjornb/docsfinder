open Folders

type SkipMissingOption = SkipMissing | IncludeMissing

type CommandLineOptions = {
    skipMissing: SkipMissingOption;
    path: string
    }

let printUsage() =
    printfn "Usage: DocsFinder.exe [--skipMissing] [path]"

//Parse args. Match empty array to default options. Match "--skipMissing" to skipmissing option and match path. PrintUsage if no case fits:
let parseArgs(args: string[]) =
    let defaultOptions = { skipMissing = IncludeMissing; path = "." }
    match args with
    | [||] -> defaultOptions
    | [| "--skipMissing"; path |] -> { skipMissing = SkipMissing; path = path }
    | [| "--skipMissing" |] -> { defaultOptions with skipMissing = SkipMissing }
    | [| path |] -> { defaultOptions with path = path }
    | _ -> printUsage(); exit 1

[<EntryPoint>]
let main args =
    let options = parseArgs args
    getFolders options.path |> Seq.map checkForReadme |> Seq.iter (printfn "%A")
    0 // return 0 exit code for success
