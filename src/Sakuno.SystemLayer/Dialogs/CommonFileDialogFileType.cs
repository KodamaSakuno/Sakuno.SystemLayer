using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sakuno.SystemLayer.Dialogs
{
    public class CommonFileDialogFileType
    {
        static Regex _extensionRegex = new Regex(@"(?:\*\.|\.)?(\w+|\*)");

        public string Name { get; set; }

        public IList<string> Extensions { get; }

        public bool Default { get; set; }

        public CommonFileDialogFileType(string name, string extensions)
        {
            Name = name;

            var extensionSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (Match match in _extensionRegex.Matches(extensions))
            {
                if (!match.Success)
                    continue;

                extensionSet.Add(match.Groups[1].Value);
            }

            Extensions = extensionSet.ToArray();
        }

        internal NativeStructs.COMDLG_FILTERSPEC ToFilterSpec()
        {
            var builder = StringBuilderCache.Acquire();

            foreach (var extension in Extensions)
            {
                if (builder.Length > 0)
                    builder.Append(';');

                builder.Append("*.");
                builder.Append(extension);
            }

            return new NativeStructs.COMDLG_FILTERSPEC()
            {
                pszName = Name,
                pszSpec = builder.GetStringAndRelease(),
            };
        }
    }
}
