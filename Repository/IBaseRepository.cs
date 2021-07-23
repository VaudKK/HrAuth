using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrAuth.Repository{

    public interface IBaseRepository<T,R>
    {
        Task SaveAsync(R Value);
        Task SaveAllAsync(IEnumerable<R> Values);
        Task<R> FindByIdAsync(T Id);
        Task DeleteAsync(T Id);
    }

}