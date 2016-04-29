using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser_CompositePattern
{
    public class Text: Composite
    {
        public override void parse(string str)
        {

            // разбиваю текст на абзацы регулярным выражением
            // в итоге я получу коллекцию абзацев
            // каждый абзац я парщу

            this.Components.Add(new Sentance());
            //абзацу передаю абзац
            
        }

        public override void show()
        {

        }

    }
}
