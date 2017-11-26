using IAWeb.Infra.Transactions;
using IAWeb.Domain.Commands.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using IAWeb.Domain.Commands.Inputs;
using IAWeb.Domain.Repositories;
using System;

namespace IAWeb.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;
        private readonly ICustomerRepository _repository;

        public CustomerController(IUow uow, CustomerCommandHandler handler, ICustomerRepository repository) : base(uow)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("v1/customers/post")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result);
        }

        [HttpGet]
        [Route("v1/customers/getById")]
        [AllowAnonymous]
        public IActionResult Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpGet]
        [Route("v1/customers/all")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet]
        [Route("v1/customers/getByUsername")]
        [AllowAnonymous]
        public IActionResult GetByUsername(string username)
        {
            return Ok(_repository.GetByUsername(username));
        }
    }
}
