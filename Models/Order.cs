﻿
using System.ComponentModel.DataAnnotations.Schema;

[Table("orders")]
public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
}