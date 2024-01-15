﻿using Application.UseCase.Orders.CreateOrder;
using Application.UseCase.Orders.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
