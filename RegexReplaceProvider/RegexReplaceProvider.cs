using System;
using System.Collections.Generic;
using Microsoft.Web.Iis.Rewrite;
using System.Text.RegularExpressions;

public class RegexReplaceProvider : IRewriteProvider, IProviderDescriptor
{
    string replacement;
    Regex regex;

    #region IRewriteProvider Members

    public void Initialize(IDictionary<string, string> settings, IRewriteContext rewriteContext)
    {
        if (!settings.TryGetValue("Pattern", out string pattern) || string.IsNullOrEmpty(pattern))
            throw new ArgumentException("Pattern provider setting is required and cannot be empty");

        if (!settings.TryGetValue("Replacement", out replacement) || replacement == null)
            throw new ArgumentException("Replacement provider setting is required and cannot be null");

        regex = new Regex(pattern);
    }

    public string Rewrite(string value)
    {
        return regex.Replace(value, replacement);
    }

    #endregion

    #region IProviderDescriptor Members

    public IEnumerable<SettingDescriptor> GetSettings()
    {
        yield return new SettingDescriptor("Pattern", "Regex Pattern");
        yield return new SettingDescriptor("Replacement", "Replacement");
    }

    #endregion
}
