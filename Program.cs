public void Process(Order? order)
{
    if (order == null)
    {
        throw new ArgumentNullException(nameof(order), "Order is null");
    }

    if (!order.IsVerified)
    {
        throw new InvalidOperationException("Order is not verified");
    }

    ValidateOrder(order);
}

private void ValidateOrder(Order order)
{
    if (order.Items.Count == 0)
    {
        throw new InvalidOperationException($"The order {order.Id} has no items");
    }

    if (order.Items.Count > 15)
    {
        throw new InvalidOperationException($"The order {order.Id} has too many items");
    }

    if (order.Status != "ReadyToProcess")
    {
        throw new InvalidOperationException($"The order {order.Id} isn't ready to process");
    }
}
