using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZhihuFind.Services.Interfaces
{
    interface ICollectionService
    { 
        Task SaveIdOrSlugAsync(int idOrSlug);
        Task DeleteIdOrSlugAsync(int idOrSlug);
        Task ReadAllIdOrSlugAsync();
        Task DeleteAllIdOrSlugAsync();
    }
}
