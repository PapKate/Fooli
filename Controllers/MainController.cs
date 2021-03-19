using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Fooli
{
    public class MainController : Controller
    {
        public MainController(FooliDBContext dbContext, IUserRepository userRepository)
        {
            DbContext = dbContext;
            UserRepository = userRepository;
        }

        public FooliDBContext DbContext { get; }
        public IUserRepository UserRepository { get; }

        [HttpPost]
        public Task<ActionResult<CategoryEntity>> AddCategoryAsync()
        {
            DbContext.Categories.Add(null);

            return null;
        }

        [HttpPut]
        public Task<ActionResult<CategoryEntity>> UpdateCategoryAsync()
        {
            DbContext.Update(null);

            UserRepository.DeleteUser(null);

            return null;
        }
    }
}
