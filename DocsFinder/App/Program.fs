open System.IO
open System

//List folders
let getFolders = Directory.EnumerateDirectories "C:\\code"

//Check for readme
let checkForReadme folder = 
    let readme = Path.Combine(folder, "readme.md")
    File.Exists readme
    
//Check readme age
let checkReadmeAge folder = 
    let readme = Path.Combine(folder, "readme.md")
    let lastWriteTime = File.GetLastWriteTime readme
    let now = DateTime.Now
    (now - lastWriteTime).TotalDays

[<EntryPoint>]
let main argv = 
    //Get folders, then check for readme and print input and output
    getFolders |> Seq.map (fun folder -> folder, checkForReadme folder) |> Seq.iter (printfn "%A")
    0 // return 0 exit code for success
