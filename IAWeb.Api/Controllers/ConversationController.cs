using IAWeb.Domain.Commands.Handlers;
using IAWeb.Domain.Commands.Inputs;
using IAWeb.Domain.Repositories;
using IAWeb.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IAWeb.Api.Controllers
{
    public class ConversationController : BaseController
    {
        private readonly ConversationCommandHandler _handler;
        private readonly IConversationRepository _repository;

        public ConversationController(IUow uow, ConversationCommandHandler handler, IConversationRepository repository) : base(uow)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/conversation/post")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterConversationCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1/conversation/all")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet]
        [Route("v1/conversation/getByQuestion")]
        [AllowAnonymous]
        public IActionResult GetByUsername(string question)
        {
            return Ok(_repository.GetByQuestion(question));
        }
    }
}
