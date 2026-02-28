using Moq;
using OrderTracker.Core.Entities;
using OrderTracker.Core.Enums;
using OrderTracker.Core.Exceptions;
using OrderTracker.Core.Interfaces;
using OrderTracker.Core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrderTracker.UnitTests.Services;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> _repoMock;
    private readonly OrderService _service;

    public OrderServiceTests()
    {
        _repoMock = new Mock<IOrderRepository>();
        _service = new OrderService(_repoMock.Object);
    }

    private Order CreateOrder(OrderStatus status = OrderStatus.PLACED)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            Email = "test@gmail.com",
            Mobile = "9999999999",
            Status = status,
            Notes = new List<OrderNote>(),
            Timeline = new List<OrderTimeline>()
        };
    }

    [Fact]
    public void UpdateStatus_ValidTransition_ShouldChangeStatus()
    {
        var order = CreateOrder(OrderStatus.PLACED);

        _repoMock.Setup(r => r.Get(order.Id)).Returns(order);

        _service.UpdateStatus(order.Id, OrderStatus.PAID);

        Assert.Equal(OrderStatus.PAID, order.Status);
        Assert.Single(order.Timeline);
    }

    [Fact]
    public void UpdateStatus_InvalidTransition_ShouldThrowValidationException()
    {
        var order = CreateOrder(OrderStatus.DELIVERED);

        _repoMock.Setup(r => r.Get(order.Id)).Returns(order);

        Assert.Throws<ValidationException>(() =>
            _service.UpdateStatus(order.Id, OrderStatus.SHIPPED));
    }

    [Fact]
    public void AddNote_MessageTooLong_ShouldThrowValidationException()
    {
        var order = CreateOrder();

        _repoMock.Setup(r => r.Get(order.Id)).Returns(order);

        var longMessage = new string('a', 501);

        Assert.Throws<ValidationException>(() =>
            _service.AddNote(order.Id, "admin", longMessage));
    }

    [Fact]
    public void Search_ShouldReturnMatchingEmail()
    {
        var orders = new List<Order>
        {
            CreateOrder(),
            new Order
            {
                Id = Guid.NewGuid(),
                Email = "other@yahoo.com",
                Mobile = "8888888888",
                Status = OrderStatus.PLACED
            }
        };

        _repoMock.Setup(r => r.GetAll()).Returns(orders);

        var result = _service.Search("gmail");

        Assert.Single(result);
    }

    [Fact]
    public void GetById_NonExistentOrder_ShouldThrowNotFoundException()
    {
        _repoMock.Setup(r => r.Get(It.IsAny<Guid>())).Returns((Order?)null);

        Assert.Throws<NotFoundException>(() =>
            _service.GetById(Guid.NewGuid()));
    }
}