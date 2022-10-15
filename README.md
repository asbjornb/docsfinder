# DocsFinder

Small cli tool to assist in keeping docs up to date.

Find repos without documentation or repos with large changes without changes to documentation. Heavily inspired (idea copied) from [docdoc](https://github.com/pmcelhaney/docdoc). Written as an exercise for myself to learn F# basics.

## Usage

If code has changed significantly since its corresponding README file was last updated, the README is probably overdue for a check up. 

```sh
$ DocFinder

Checking on the health of README.md files...

 86.63% ./account/activity
      ! ./app
      ! ./home/iframes
 59.79% ./home/widgets
      ! ./utilities/report

You have 2 outdated and 3 missing README.md files!      
```

A percentage next to a directory means the directory has changed that much (according to Git)
since its README.md file was last updated. You might want to give that README some attention!

A "!" next to a directory means the README.md file is missing altogether.

If any problems are found docdoc will exit with code 1, so you can add it to your build system.

### Options

Calling with a relative or absolute path checks there rather than from current location:

```sh
DocFinder ./subfolder
```

The `--skipMissing` flag causes docdoc to ignore directories that don't have a README.md.

The `--threshhold=n` option sets percent change you want to allow before a README is considered
outdated.
