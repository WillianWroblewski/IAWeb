using IAWeb.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IAWeb.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result)
        {
            try
            {
                _uow.Commit();
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            catch
            {
                // Logar o erro (Elmah)
                return BadRequest(new
                {
                    success = false,
                    errors = new[] { "IAWeb: Ocorreu uma falha interna no servidor." }
                });
            }
        }
    }
}
