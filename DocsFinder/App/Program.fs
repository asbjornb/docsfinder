open System.IO
open System

//List folders
let getFolders = Directory.EnumerateDirectories

//Check for readme
let checkForReadme folder = 
    let readme = Path.Combine(folder, "readme.md")
    (folder, File.Exists readme)
    
//Check readme age
let checkReadmeAge folder = 
    let readme = Path.Combine(folder, "readme.md")
    let lastWriteTime = File.GetLastWriteTime readme
    let now = DateTime.Now
    (folder, (now - lastWriteTime).TotalDays)

[<EntryPoint>]
let main argv =
    // Get optional path positional argument
    let path = 
        if argv.Length > 0 then argv.[0]
        else Environment.CurrentDirectory
    
    //Get folders, then check for readme and print results
    getFolders path |> Seq.map checkForReadme |> Seq.iter (printfn "%A")
    0 // return 0 exit code for success
