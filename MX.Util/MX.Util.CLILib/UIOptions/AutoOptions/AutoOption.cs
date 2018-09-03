using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions.AutoOptions
{
    public class AutoOption : UISelectDelegateOption
    {

        public bool UsePrefixNumber { get; internal set; }
        public bool UseShortcutCharacter { get; internal set; }

        public int PrefixNumber { get; internal set; }
        public int ShortcutCharacterIndex { get; internal set; }

        public string OriginalTitle { get; private set; }
        public override string Title => ParsedTitle(OriginalTitle);
        
        public AutoOption(string title)
        {
            OriginalTitle = title;
        }

        public override bool IsMatch(ICLICommand command)
        {
            return ( UseShortcutCharacter && StrCompare(command.Command, OriginalTitle[ShortcutCharacterIndex].ToString()) ) ||
                   ( UsePrefixNumber && StrCompare(command.Command, PrefixNumber.ToString()) );
        }

        private bool StrCompare(string lhs, string rhs)
        {
            return String.Equals(lhs, rhs, StringComparison.OrdinalIgnoreCase);
        }

        private string ParsedTitle(string originalTitle)
        {
            var sb = new StringBuilder(originalTitle);

            if (UseShortcutCharacter)
            {
                sb.Insert(ShortcutCharacterIndex, '[');
                sb.Insert(ShortcutCharacterIndex + 2, ']');
            }

            if (UsePrefixNumber)
                sb.Insert(0, PrefixNumber + ") ");

            return sb.ToString();

        }
    }
}
