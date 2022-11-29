open Folders

type SkipMissingOption = SkipMissing | IncludeMissing

type CommandLineOptions = {
    skipMissing: SkipMissingOption;
    path: string
    }

let printUsage() =
    printfn "Usage: DocsFinder.exe [--skipMissing] [path]"

//Parse args. Match empty array to default options. Match "--skipMissing" to skipmissing option and match path. PrintUsage if no case fits:
let parseArgs (args: string list) =
  let rec parse (options: CommandLineOptions) (args: string list) =
    match args with
    | [] -> options
    | [x] -> { options with path = x }
    | x :: xs ->
      match x with
      | "--skipMissing" -> parse { options with skipMissing = SkipMissing } xs
      | _ -> printUsage(); exit 1

  parse { skipMissing = IncludeMissing; path = "." } args

[<EntryPoint>]
let main args =
    let options = parseArgs (args |> Array.toList)
    //filter on exists if skipmissing is set
    let filter (_, exists) = options.skipMissing=IncludeMissing || exists
    //Format output to string and reverse parameters
    let format (folder, exists) = sprintf "%b %s" exists folder
    //getFolders at path, check if they have readme with checkForReadme, format, then print results
    getFolders options.path |> Seq.map checkForReadme |> Seq.filter filter |> Seq.map format |> Seq.iter (printfn "%A")
    0 // return 0 exit code for success
