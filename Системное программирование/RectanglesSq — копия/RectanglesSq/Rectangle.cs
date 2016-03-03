using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RectanglesSq
{
    class Rectangle
    {
        private ManualResetEvent _doneEvent;
        public int W { get { return _w; } }
        private int _w;

        public int H { get { return _h; } }
        private int _h;

        public int S { get { return _s; } }
        private int _s;
        public Rectangle(int w, int h, ManualResetEvent doneEvent)
        {
            _w = w;
            _h = h;
            _doneEvent = doneEvent;
        }

        public int Calculate()
        {
            return _w * _h;
        }

        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            _s = Calculate();
            Console.WriteLine("thread {0} result calculated...", threadIndex);
            if(Interlocked.Decrement(ref Program.count) == 0)
            {
                _doneEvent.Set();
            }
        }
    }
}
