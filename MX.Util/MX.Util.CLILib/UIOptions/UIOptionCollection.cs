using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.CLILib.UIOptions
{
    public class UIOptionCollection : IUIOptionCollection
    {

        public IEnumerable<IUIOption> ActiveOptions => _options.Where(opt => opt.Enabled);
        public IEnumerable<IUIOption> Options       => _options;

        private UIOptionFactory _factory = new UIOptionFactory();
        private List<IUIOption> _options = new List<IUIOption>();

        public static UIOptionCollection ToCollection(UIOption option)
        {
            var collection = new UIOptionCollection();
            collection.Add(option);
            return collection;
        }

        public static UIOptionCollection ToCollection(IEnumerable<UIOption> options)
        {
            var collection = new UIOptionCollection();
            collection.Add(options);
            return collection;
        }

        public void Add(IUIOption option)               => _options.Add(option);
        public void Add(IEnumerable<IUIOption> options) => _options.AddRange(options);
        public void Add(string title, IEnumerable<string> triggers, Action<ICLICommand> selectFunc) => Add(_factory.Create(title, triggers, selectFunc));
        public void Add(IEnumerable<string> triggers, Action<ICLICommand> selectFunc)               => Add(_factory.Create(triggers, selectFunc));

        public IEnumerator<IUIOption> GetEnumerator()
        {
            return ActiveOptions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
