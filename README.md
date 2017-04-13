# RegexReplaceProvider

RegexReplaceProvider is a custom provider for the [IIS URL Rewrite](https://www.iis.net/downloads/microsoft/url-rewrite) module that
allows you to perform string replacements using regexes.

## Installation

Grab a zip from a [Release](https://github.com/mganss/RegexReplaceProvider/releases) and unpack it into any folder. 
Then launch a command prompt as Administrator, cd into the folder and enter:

```
powershell .\gacutil.ps1 -i RegexReplaceProvider.dll
```

To add the provider to your site through IIS manager do the following:

- Select your site
- Double-click URL Rewrite
- Click "View Providers..." on the Actions menu at the right side
- Click "Add Provider..." on the Actions menu
- Choose a name for the provider, e.g. "SpaceToHyphen" (you'll have to add a provider for each regex and replacement you want to use)
- Choose RegexReplaceProvider from the dropdown

To configure the provider:

- Click "Add Provider Setting..." on the Actions menu
- Choose "Regex Pattern" and enter the pattern in the "Value" textbox, e.g. "(%20)+" to match all spaces
- Add another provider setting to set the replacement string, e.g. "-" to replace any number of spaces with a single hyphen

The syntax of [.NET Framework regular expressions](https://docs.microsoft.com/en-us/dotnet/articles/standard/base-types/regular-expression-language-quick-reference) is used. The replacement string can contain [substitutions](https://docs.microsoft.com/en-us/dotnet/articles/standard/base-types/regular-expression-language-quick-reference#substitutions), e.g. "$1" refers to the first group in the match.

You can then use the provider in the redirect URL of a rule action like this:

```
example/{SpaceToHyphen:{R:1}}
```

`SpaceToHyphen` in this example is the name of the provider you have assigned when adding the provider above.

