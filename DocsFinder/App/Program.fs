open System.IO
open System

//List folders
let GetFolders = Directory.EnumerateDirectories "C:\\code"

//Check for readme
let CheckForReadme folder = 
    let readme = Path.Combine(folder, "readme.md")
    File.Exists readme
    
//Check readme age
let CheckReadmeAge folder = 
    let readme = Path.Combine(folder, "readme.md")
    let lastWriteTime = File.GetLastWriteTime readme
    let now = DateTime.Now
    (now - lastWriteTime).TotalDays

[<EntryPoint>]
let main argv = 
    //Get folders, then check for readme and print input and output
    GetFolders |> Seq.map (fun folder -> folder, CheckForReadme folder) |> Seq.iter (printfn "%A")
    0 // return 0 exit code for success
