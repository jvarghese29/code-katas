namespace ShoppingCart.Tests;

public class CheckoutTests
{
    [Test]
    public void AnEmptyCartProducesAZeroReceipt()
    {
        var checkout = new Checkout();

        Assert.That(checkout.CalculateTotal(), Is.EqualTo(0));
    }
}