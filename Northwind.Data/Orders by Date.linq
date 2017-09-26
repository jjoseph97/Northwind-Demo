<Query Kind="Statements">
  <Connection>
    <ID>6e484abb-c891-4160-85c2-2e92aba6bcb4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

//Get the following from the Orders/OrderDetails for the last month of business data 
//OrderDate, OrderID, # Items, Subtotal of all items, Total with freight 
//Display this information along with the total income for the month and the number of orders
//processed.
var maxDate = Orders.Max(row => row.OrderDate);
maxDate.Value.Month.Dump();
var lastMonthOrders = from data in Orders
					  where data.OrderDate.Value.Month == maxDate.Value.Month
					  	&& data.OrderDate.Value.Year == maxDate.Value.Year
					  orderby data.OrderDate
					  select new 
					  {
					  	OrderDate = data.OrderDate,
						OrderID = data.OrderID,
						NumberOfItems = data.OrderDetails.Count(),
						ItemSubtotals = (from item in data.OrderDetails
									    select item.UnitPrice * item.Quantity).Sum(),
						FreightCost = data.Freight,
						Total = data.Freight + (from item in data.OrderDetails
									    select item.UnitPrice * item.Quantity).Sum() 
					  };
lastMonthOrders.Dump();
var totalIncome = lastMonthOrders.Sum(x => x.Total);
var count = lastMonthOrders.Count();
totalIncome.Dump("Total Income");
count.Dump("# of orders Processed");



//Orders.Take(5) //get the first 5 orders
//Orders.Count
from data in Orders
orderby data.OrderDate descending //newest to oldest 
select new 
{
OrderDate = data.OrderDate 
}