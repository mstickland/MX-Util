using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions.AutoOptions
{
    [Flags]
    public enum AutoOptionMode
    {
        DoNothing            = 0x0,
        AddNumberPrefixes    = 0x1,
        AddShortcutCharacter = 0x1 << 1,
    }

    public class AutoUIOptionCollection : IUIOptionCollection 
    {
        
        public IEnumerable<IUIOption> ActiveOptions => _options.Where(opt => opt.Enabled);
        public IEnumerable<IUIOption> Options => _options;

        private List<AutoOption> _options   = new List<AutoOption>();
        private List<char> _takenCharacters = new List<char>();

        public AutoOptionMode Mode {  get; private set; }


        public AutoUIOptionCollection()
        {
            Mode = AutoOptionMode.AddNumberPrefixes | AutoOptionMode.AddShortcutCharacter;
        }

        public AutoUIOptionCollection(AutoOptionMode mode)
        {
            Mode = mode;
        }

        public void Add(string title, Action<ICLICommand> selectFunc) 
        {
            
            AutoOption option = CreateOption(title);
            option.SelectFunc = selectFunc;

            _options.Add(option);
        }

        public void Add(string title, char preferredCharacter, Action<ICLICommand> selectFunc)
        {

            AutoOption option = CreateOption(title, preferredCharacter);
            option.SelectFunc = selectFunc;

            _options.Add(option);
        }

        private AutoOption CreateOption(string title, char preferredCharacter)
        {
            int charIndex = GetShortCharacter(title, preferredCharacter);
            return new AutoOption(title)
            {
                UsePrefixNumber = Has(AutoOptionMode.AddNumberPrefixes),
                UseShortcutCharacter = charIndex >= 0,
                PrefixNumber = _options.Count + 1,
                ShortcutCharacterIndex = charIndex,
            };
        }

        private AutoOption CreateOption(string title)
        {
            int charIndex = GetShortCharacter(title);
            return new AutoOption(title)
            {
                UsePrefixNumber        = Has(AutoOptionMode.AddNumberPrefixes),
                UseShortcutCharacter   = charIndex >= 0,
                PrefixNumber           = _options.Count + 1,
                ShortcutCharacterIndex = charIndex,
            };
        }

        private int GetShortCharacter(string title, char c)
        {
            if (!Has(AutoOptionMode.AddShortcutCharacter))
                return - 1;

            int cindex = title.IndexOf(c);

            if (cindex <= 0 || _takenCharacters.Contains(c))
                return GetShortCharacter(title);

            return cindex;

        }

        private int GetShortCharacter(string title)
        {
            if(!Has(AutoOptionMode.AddShortcutCharacter))
                return -1;

            int charIndex = FindAvailableCharacter(title);
            if(charIndex >= 0)
                _takenCharacters.Add(title[charIndex]);

            return charIndex;
        }
        private int FindAvailableCharacter(string title)
        {
            for (int i = 0; i < title.Length; ++i)
            {
                if (!_takenCharacters.Any(c => Char.ToUpper(c) == Char.ToUpper(title[i])))
                    return i;
            }
            
            return -1;
        }

        private bool Has(AutoOptionMode mode)
        {
            return (Mode & mode) != 0;
        }

        public void Add(string v1, char v2, Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IUIOption> GetEnumerator()
        {
            return ActiveOptions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
