# RegexReplaceProvider

RegexReplaceProvider is a custom provider for the [IIS URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module that
allows you to perform string replacements using regexes.

## Installation

Grab a zip from a [Release](https://github.com/mganss/RegexReplaceProvider/releases) and unpack it into any folder. 
Then launch a command prompt as Administrator, cd into the folder and enter:

```
powershell .\gacutil.ps1 -i RegexReplaceProvider.dll
```
