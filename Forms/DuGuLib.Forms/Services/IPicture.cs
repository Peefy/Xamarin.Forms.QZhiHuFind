using System;
namespace DuGu.XFLib.Services
{
    public interface IPicture
    {
        void SavePictureToDisk(string filename, byte[] imageData);
    }
}
