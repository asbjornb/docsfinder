module Folders

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

