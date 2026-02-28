using Microsoft.AspNetCore.Mvc;
using Orderops.api.Models;
using OrderTracker.Core.Interfaces;

namespace OrderTracker.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Search([FromQuery] string query)
        => Ok(_service.Search(query));

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
        => Ok(_service.GetById(id));

    [HttpPost("{id}/notes")]
    public IActionResult AddNote(Guid id, AddNoteRequest request)
    {
        _service.AddNote(id, request.Author, request.Message);
        return Ok();
    }

    [HttpPost("{id}/status")]
    public IActionResult UpdateStatus(Guid id, UpdateStatusRequest request)
    {
        _service.UpdateStatus(id, request.Status);
        return Ok();
    }
}