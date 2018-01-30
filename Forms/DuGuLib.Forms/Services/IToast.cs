using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuGu.XFLib.Services
{
    public interface IToast
    {
        void Show(string msg, bool longShow = false);
    }
}
