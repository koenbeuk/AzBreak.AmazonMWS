namespace AzBreak.AmazonMWS.Orders
{
    public class PointsGranted
    {
        /// <summary>
        /// The number of Amazon Points granted with the purchase of an item.	
        /// </summary>
        public int? PointsNumber { get; set; }

        /// <summary>
        /// The monetary value of the Amazon Points granted
        /// </summary>
        public Money PointsMonetaryValue { get; set; }
    }
}