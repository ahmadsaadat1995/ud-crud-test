using CRM.Application.Customers.Commands.CreateCustomer;
using CRM.Application.Customers.Commands.DeleteCustomer;
using CRM.Application.Customers.Commands.RestoreCustomer;
using CRM.Application.Customers.Commands.UpdateCustomer;
using CRM.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRM.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerService;
        private readonly IMediator _mediator;

        public CustomerController(ICustomerRepository customerService, IMediator mediator)
        {
            _customerService = customerService;
            _mediator = mediator;
        }

        // POST: api/customer
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CreateCustomerCommand command)
        {
            if (command == null)
            {
                return BadRequest(new { message = "داده‌های ورودی معتبر نیست" });
            }

            var customer = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = command }, customer);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest(new { message = "اطلاعات مشتری معتبر نیست" });
            }

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "مشتری پیدا نشد" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = "اعتبارسنجی ناموفق بود", errors = ex.ValidationResult });
            }
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "مشتری پیدا نشد" });
            }
            return Ok(customer);
        }

        // GET: api/customer
        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }

        // PUT: api/customers/restore/{id}
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCustomer(Guid id)
        {
            await _mediator.Send(new RestoreCustomerCommand(id));
            return NoContent();
        }

    }
}
